using had.eventdispatcher;
using System;
using UnityEngine;

public partial class EventDispatcher : Component {
    private static EventDispatcher instance = null;
    public static EventDispatcher Instance {
        get {
            if(instance == null) {
                Debug.LogFormat("Create empty instance", typeof(EventDispatcher));
                instance = new GameObject("EventDispatcher").AddComponent<EventDispatcher>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }
    /**<summary> Becarefull. Should use when your game has only one scene, or all your game logic place in only one scene (except logoscene).</summary>*/
    public void RemoveAllListener() {
        if (intEventObserver != null) intEventObserver.RemoveAllListener();
        if (stringEventObserver != null) stringEventObserver.RemoveAllListener();
        if (paramsEventObserver != null) paramsEventObserver.RemoveAllListener();
        GC.Collect();
    }
}