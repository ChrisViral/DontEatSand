using System.Collections.Generic;
using DontEatSand.Entities.Units;
using UnityEngine;

namespace DontEatSand
{
    public class PlayerUnitController : MonoBehaviour
    {
        private Camera cam;
        private RaycastHit hit;
        private Vector3 mousePosition;
        private readonly List<Unit> selectedUnits = new List<Unit>();

        // Start is called before the first frame update
        private void Start() => this.cam = GameObject.Find("RTSCamera").GetComponent<Camera>();

        // Update is called once per frame
        private void Update()
        {
            //Detect mouse left click
            if (Input.GetMouseButtonDown(0))
            {
                this.mousePosition = Input.mousePosition;
                //Create a ray from the camera to the scene
                Ray camRay = this.cam.ScreenPointToRay(Input.mousePosition);
                //Shoot the ray
                if (Physics.Raycast(camRay, out this.hit))
                {
                    if (this.hit.transform.CompareTag("target"))
                    {
                        SelectUnit(this.hit.transform.GetComponent<Unit>());
                    }
                    else
                    {
                        DeselectUnits();
                    }
                }

            }

            //Detect mouse right click
            if (Input.GetMouseButtonDown(1))
            {
                this.mousePosition = Input.mousePosition;
                //Create a ray from the camera to the scene
                Ray camRay = this.cam.ScreenPointToRay(Input.mousePosition);
                //Shoot the ray
                if (Physics.Raycast(camRay, out this.hit))
                {
                    Vector3 averagePosition = Vector3.zero;
                    foreach (Unit unit in this.selectedUnits)
                    {
                        averagePosition += unit.transform.position;
                    }

                    averagePosition /= this.selectedUnits.Count;
                    foreach (Unit unit in this.selectedUnits)
                    {
                        unit.MoveUnit(this.hit.point, averagePosition);
                    }
                }

            }
        }

        private void SelectUnit(Unit unit)
        {
            if (!this.selectedUnits.Contains(unit))
            {
                this.selectedUnits.Add(unit);
            }

            Debug.Log(this.selectedUnits.Count);
        }

        private void DeselectUnits() => this.selectedUnits.Clear();
    }
}