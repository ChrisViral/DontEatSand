using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DontEatSand.Base;
using DontEatSand.Entities.Units;
using DontEatSand.Extensions;
using DontEatSand.Utils;
using Photon.Pun;
using RTSCam;
using UnityEngine;

namespace DontEatSand.Entities.Buildings
{
    public class Castle : Entity, IComparable<Castle>
    {
        #region Fields
        [SerializeField]
        private Transform spawnLocation;
        [SerializeField]
        private int buildQueueMaxSize = 10;
        [SerializeField]
        private Vector3 startCameraPosition, startCameraRotation;
        [SerializeField]
        private Sandpit visibleSandpit;
        private readonly LinkedList<Unit> buildQueue = new LinkedList<Unit>();
        private readonly Timer buildTimer = new Timer();
        private UnitInfo inProgress;
        #endregion

        #region Properties
        [SerializeField]
        private int id;
        /// <summary>
        /// ID of this player
        /// </summary>
        public int ID => this.id;

        [SerializeField, Tooltip("All the units that can be created by this castle")]
        private Unit[] units;
        /// <summary>
        /// A list of all the units that can be created by this Castle
        /// </summary>
        public ReadOnlyCollection<Unit> Units { get; private set; }

        /// <summary>
        /// If there is still room in the build queue to add other units
        /// </summary>
        public bool CanBuild => this.buildQueue.Count < this.buildQueueMaxSize;

        /// <summary>
        /// If this castle is currently building units
        /// </summary>
        public bool IsBuilding => this.buildQueue.Count > 0;

        /// <summary>
        /// The remaining build time in percent of this unit, 0 if no unit is being made
        /// </summary>
        public float BuildProgress => this.IsBuilding ? 1f - (this.buildTimer.ElapsedSeconds / this.inProgress.BuildTime) : 0f;
        #endregion

        #region Methods
        /// <summary>
        /// Creates the Entity at the given index in the castle's units list
        /// </summary>
        /// <param name="index">Index of the unit to create in the entity list</param>
        /// <exception cref="ArgumentOutOfRangeException">If the index is out of range of the entity list</exception>
        public void CreateEntity(int index)
        {
            //Check for index range
            if (index < 0 && index >= this.units.Length) throw new ArgumentOutOfRangeException(nameof(index), index, "Index must be within the range of the units list");

            //Check for room in the queue
            if (!this.CanBuild)
            {
                this.LogWarning("Build queue is full, new unit cannot be created");
                return;
            }

            //Get unit info
            Unit unit = this.units[index];
            UnitInfo info = unit.Info;

            //Check if we have the resources to create it
            if (RTSPlayer.Instance.CheckResourcesAvailable(info.SandCost, info.CandyCost))
            {
                //Request resources
                if (info.SandCost > 0)
                {
                    GameEvents.OnSandChanged.Invoke(-info.SandCost);
                }
                if (info.CandyCost > 0)
                {
                    GameEvents.OnCandyChanged.Invoke(info.CandyCost);
                }

                //Add unit to build queue
                this.buildQueue.AddLast(unit);
                if (this.buildQueue.Count == 1)
                {
                    this.buildTimer.Start();
                    this.inProgress = info;
                }
                GameEvents.OnUnitAddedToQueue.Invoke(info);
            }
        }

        /// <summary>
        /// Pops the first element of the build queue and starts the next one if needed
        /// </summary>
        private void PopQueue()
        {
            //Remove first unit
            this.buildQueue.RemoveFirst();
            //Check if more units in queue
            if (this.IsBuilding)
            {
                this.inProgress = this.buildQueue.First.Value.Info;
                this.buildTimer.Restart();
            }
            else
            {
                this.inProgress = default;
                this.buildTimer.Reset();
            }
        }

        /// <summary>
        /// Listens to the unit removed event and removes the unit from the build queue, then returns the resources
        /// </summary>
        /// <param name="index">Index of the unit to remove from the queue</param>
        private void OnUnitRemovedFromQueue(int index)
        {
            if (index < 0 || index > this.buildQueue.Count)
            {
                this.LogWarning("Trying to remove unit outside of queue range");
                return;
            }

            UnitInfo removed;
            if (index == 0)
            {
                removed = this.buildQueue.First.Value.Info;
                PopQueue();
            }
            else if (index == this.buildQueue.Count - 1)
            {
                //Optimize if last
                removed = this.buildQueue.Last.Value.Info;
                this.buildQueue.RemoveLast();
            }
            else
            {
                //ReSharper disable PossibleNullReferenceException
                //Traverse list to find node
                LinkedListNode<Unit> toRemove;
                if (index > this.buildQueue.Count / 2)
                {
                    //If closer to end go backwards
                    toRemove = this.buildQueue.Last.Previous;
                    for (int i = this.buildQueue.Count - 2; i > index; i--)
                    {
                        toRemove = toRemove.Previous;
                    }
                }
                else
                {
                    //Else go forwards
                    toRemove = this.buildQueue.First.Next;
                    for (int i = 1; i < index; i++)
                    {
                        toRemove = toRemove.Next;
                    }
                }

                removed = toRemove.Value.Info;
                this.buildQueue.Remove(toRemove);
                //ReSharper enable PossibleNullReferenceException
            }

            //Give back resources
            if (removed.SandCost > 0)
            {
                GameEvents.OnSandChanged.Invoke(removed.SandCost);
            }
            if (removed.CandyCost > 0)
            {
                GameEvents.OnCandyChanged.Invoke(-removed.CandyCost);
            }

        }

        /// <inheritdoc cref="IComparable{T}.CompareTo"/>
        public int CompareTo(Castle other) => this.id.CompareTo(other.id);
        #endregion

        #region Functions
        protected override void OnAwake()
        {
            this.Units = Array.AsReadOnly(this.units);
            if (PhotonNetwork.IsConnected)
            {
                this.enabled = false;
            }
        }

        protected override void OnStart()
        {
            if (RTSPlayer.Instance.Castle == this)
            {
                //Setup
                this.visibleSandpit.Visible = true;
                Camera cam = Camera.main;
                RTSCamera rtsCam = cam.GetComponent<RTSCamera>();
                Transform parent = cam.transform.parent;
                cam.orthographicSize = 15;
                parent.position = this.startCameraPosition;
                parent.rotation = Quaternion.Euler(this.startCameraRotation);
                rtsCam.enabled = true;
                GameEvents.OnUnitRemovedFromQueue.AddListener(OnUnitRemovedFromQueue);

                //Create a farmer
                Unit farmer = this.units[5];
                if (PhotonNetwork.IsConnected)
                {
                    GameObject go = PhotonNetwork.Instantiate(farmer.name, this.spawnLocation.position, farmer.transform.rotation);
                    go.transform.SetParent(this.transform.parent, true);
                }
                else
                {
                    Instantiate(farmer, this.spawnLocation.position, farmer.transform.rotation, this.transform.parent);
                }
            }
        }

        private void Update()
        {
            //Check if building, if so check for completion of current unit
            if (this.IsControllable() && this.IsBuilding && this.buildTimer.Elapsed.TotalSeconds >= this.inProgress.BuildTime)
            {
                //Get unit and spawn it
                Unit unit = this.buildQueue.First.Value;
                Unit clone = PhotonUtils.Instantiate(unit, this.spawnLocation.position, unit.transform.rotation, this.transform.parent);
                GameEvents.OnUnitCreated.Invoke(clone);

                //Pop build queue
                PopQueue();
            }
        }

        private void OnDestroy()
        {
            if (this.IsControllable())
            {
                GameEvents.OnUnitRemovedFromQueue.RemoveListener(OnUnitRemovedFromQueue);
            }
        }
        #endregion
    }
}
