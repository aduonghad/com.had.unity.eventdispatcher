/** <summary> 
 * Uncomment the define INT_OBSERVER to use int/enum key in EventDispatcher
 * </summary> */
using System;
using UnityEngine;

using had.eventdispatcher;

public partial class EventDispatcher : Component {
    private IntEventObserver intEventObserver = null;
    private IntEventObserver IntEventObserver {
        get {
            if(intEventObserver != null) { return intEventObserver; }
            intEventObserver = new IntEventObserver();
            return intEventObserver;
        }
    }

    #region int Key
    /**<summary>IntEventObserver listener</summary> */
    public void Dispatch(int key, object value = null, bool showDebugLog = false) {
        IntEventObserver.Dispatch(key, value, showDebugLog);
    }

    /**<summary>IntEventObserver listener</summary> */
    public void AddListener(int key, Action<object> eventCallback, bool showDebugLog = false) {
        IntEventObserver.AddListener(key, eventCallback, showDebugLog);
    }

    /**<summary>IntEventObserver listener</summary> */
    public void AddListener(int key, Action eventCallback, bool showDebugLog = false) {
        IntEventObserver.AddListener(key, eventCallback, showDebugLog);
    }

    /**<summary>IntEventObserver listener</summary> */
    public void RemoveListener(int key, Action<object> eventCallback, bool showDebugLog = false) {
        IntEventObserver.RemoveListener(key, eventCallback, showDebugLog);
    }

    /**<summary>IntEventObserver listener</summary> */
    public void RemoveListener(int key, Action eventCallback, bool showDebugLog = false) {
        IntEventObserver.RemoveListener(key, eventCallback, showDebugLog);
    }

    /** <summary> Remove ALL callback listener by `key`. Be carefully, use at OnDestroy only to free RAM. </summary> */
    public void RemoveListener(int key) {
        IntEventObserver.RemoveListener(key);
    }
    #endregion
}