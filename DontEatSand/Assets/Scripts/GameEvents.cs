using System;
using System.Collections.Generic;
using DontEatSand.Entities.Units;

namespace DontEatSand
{
    /// <summary>
    /// Collections of game wide events
    /// </summary>
    public static class GameEvents
    {
        #region Delegates
        /// <summary>
        /// Parameter-less event delegate
        /// </summary>
        public delegate void Event();

        /// <summary>
        /// Event delegate with one parameter
        /// </summary>
        /// <typeparam name="T">Event parameter type</typeparam>
        /// <param name="t">Event parameter</param>
        public delegate void Event<in T>(T t);

        /// <summary>
        /// Event delegate with two parameter
        /// </summary>
        /// <typeparam name="T1">Event first parameter type</typeparam>
        /// <typeparam name="T2">Event second parameter type</typeparam>
        /// <param name="t1">Event first parameter</param>
        /// <param name="t2">Event second parameter</param>
        public delegate void Event<in T1, in T2>(T1 t1, T2 t2);

        /// <summary>
        /// Event delegate with three parameter
        /// </summary>
        /// <typeparam name="T1">Event first parameter type</typeparam>
        /// <typeparam name="T2">Event second parameter type</typeparam>
        /// <typeparam name="T3">Event third parameter type</typeparam>
        /// <param name="t1">Event first parameter</param>
        /// <param name="t2">Event second parameter</param>
        /// <param name="t3">Event third parameter</param>
        public delegate void Event<in T1, in T2, in T3>(T1 t1, T2 t2, T3 t3);
        #endregion

        #region Classes
        /// <summary>
        /// Base generic template class for GameEvents
        /// </summary>
        /// <typeparam name="T">Type of delegate used by the event</typeparam>
        public abstract class EventBase<T> where T : Delegate
        {
            #region Fields
            //Invocation list
            private readonly List<T> events = new List<T>();
            #endregion

            #region Properties
            /// <summary>
            /// Listener list ready for invocation
            /// </summary>
            protected List<T> Event => new List<T>(this.events);
            #endregion

            #region Methods
            /// <summary>
            /// Adds an delegate to be an event listener
            /// </summary>
            /// <param name="listener">Delegate listening to the event</param>
            public void AddListener(T listener) => this.events.Add(listener);

            /// <summary>
            /// Removes a delegate from listening to the event
            /// </summary>
            /// <param name="listener">Delegate to remove from the event</param>
            public void RemoveListener(T listener) => this.events.Remove(listener);

            /// <summary>
            /// Removes all the listeners from the event
            /// </summary>
            public void RemoveAllListeners() => this.events.Clear();
            #endregion
        }

        /// <summary>
        /// Parameter-less game event
        /// </summary>
        public class GameEvent : EventBase<Event>
        {
            #region Methods
            /// <summary>
            /// Invokes the event
            /// </summary>
            public void Invoke() => this.Event.ForEach(e => e());
            #endregion
        }

        /// <summary>
        /// Game event with one parameter
        /// </summary>
        /// <typeparam name="T">Event parameter type</typeparam>
        public class GameEvent<T> : EventBase<Event<T>>
        {
            #region Methods
            /// <summary>
            /// Invokes the event
            /// <param name="t">Parameter of the event</param>
            /// </summary>
            public void Invoke(T t) => this.Event.ForEach(e => e(t));
            #endregion
        }

        /// <summary>
        /// Game event with two parameter
        /// </summary>
        /// <typeparam name="T1">Event first parameter type</typeparam>
        /// <typeparam name="T2">Event second parameter type</typeparam>
        public class GameEvent<T1, T2> : EventBase<Event<T1, T2>>
        {
            #region Methods
            /// <summary>
            /// Invokes the event
            /// <param name="t1">First parameter of the event</param>
            /// <param name="t2">Second parameter of the event</param>
            /// </summary>
            public void Invoke(T1 t1, T2 t2) => this.Event.ForEach(e => e(t1, t2));
            #endregion
        }

        /// <summary>
        /// Game event with three parameter
        /// </summary>
        /// <typeparam name="T1">Event first parameter type</typeparam>
        /// <typeparam name="T2">Event second parameter type</typeparam>
        /// <typeparam name="T3">Event third parameter type</typeparam>
        public class GameEvent<T1, T2, T3> : EventBase<Event<T1, T2, T3>>
        {
            #region Methods
            /// <summary>
            /// Invokes the event
            /// <param name="t1">First parameter of the event</param>
            /// <param name="t2">Second parameter of the event</param>
            /// <param name="t3">Third parameter of the event</param>
            /// </summary>
            public void Invoke(T1 t1, T2 t2, T3 t3) => this.Event.ForEach(e => e(t1, t2, t3));
            #endregion
        }
        #endregion

        #region Events
        /// <summary>
        /// Event fired on game pause/unpause<para/>
        /// Parameter{<see cref="bool"/>} state: Current pause state of the game
        /// </summary>
        public static GameEvent<bool> OnPause { get; } = new GameEvent<bool>();

        /// <summary>
        /// Event fired on Game Scene load<para/>
        /// Param{<see cref="GameScenes"/>} from: Scene the game loaded from<para/>
        /// Param{<see cref="GameScenes"/>} to:   Scene the game loaded to
        /// </summary>
        public static GameEvent<GameScenes, GameScenes> OnSceneLoaded { get; } = new GameEvent<GameScenes, GameScenes>();

        /// <summary>
        /// Event fired when the Unit Database is loaded
        /// </summary>
        public static GameEvent OnUnitDatabaseLoaded { get; } = new GameEvent();

        /// <summary>
        /// Event fired when the total amount of candy available changes<para/>
        /// Param{<see cref="int"/>} amount: Amount of candy added or subtracted
        /// </summary>
        public static GameEvent<int> OnCandyMaxChanged { get; } = new GameEvent<int>();

        /// <summary>
        /// Event fired when the sand amount changes<para/>
        /// Param{<see cref="int"/>} amount: Amount of sand added or removed
        /// </summary>
        public static GameEvent<int> OnSandChanged { get; } = new GameEvent<int>();

        /// <summary>
        /// Event fired when the candy amount changes<para/>
        /// Param{<see cref="int"/>} amount: Amount of candy added or removed
        /// </summary>
        public static GameEvent<int> OnCandyChanged { get; } = new GameEvent<int>();

        /// <summary>
        /// Fired when a unit is added to this player's build queue<para/>
        /// Param{<see cref="UnitInfo"/>} unit: The unit added to the queue
        /// </summary>
        public static GameEvent<UnitInfo> OnUnitAddedToQueue { get; } = new GameEvent<UnitInfo>();

        /// <summary>
        /// Fired when a unit is removed from the player's build queue<para/>
        /// Param{<see cref="int"/>} index: Index in the queue of the unit being removed
        /// </summary>
        public static GameEvent<int> OnUnitRemovedFromQueue { get; } = new GameEvent<int>();

        /// <summary>
        /// Fired when a unit is created<para/>
        /// Param{<see cref="Unit"/>} unit: The created unit
        /// </summary>
        public static GameEvent<Unit> OnUnitCreated { get; } = new GameEvent<Unit>();

        /// <summary>
        /// Fired when a unit is destroyed
        /// Param{<see cref="Unit"/>} unit: The destroyed unit
        /// </summary>
        public static GameEvent<Unit> OnUnitDestroyed { get; } = new GameEvent<Unit>();

        /// <summary>
        /// Fired when the unit selection from the player has changed<para/>
        /// Param{<see cref="SelectionType"/>} type: The type of selection in effect
        /// </summary>
        public static GameEvent<SelectionType> OnSelectionChanged { get; } = new GameEvent<SelectionType>();
        #endregion
    }
}