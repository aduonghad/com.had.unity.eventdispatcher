/** <summary> 
 * Uncomment the define STRING_OBSERVER to use string key in EventDispatcher
 * </summary> */

#define STRING_OBSERVER


#if STRING_OBSERVER
using had.eventdispatcher;
using System;
using UnityEngine;

public partial class EventDispatcher : Component {
    private StringEventObserver stringEventObserver;
    private StringEventObserver StringEventObserver {
        get {
            if(stringEventObserver != null)
                return stringEventObserver;
            stringEventObserver = new StringEventObserver();
            return stringEventObserver;
        }
    }

    /**<summary>StringEventObserver listener</summary> */
    public void Dispatch(string key, object value = null, bool showDebugLog = false) {
        StringEventObserver.Dispatch(key, value, showDebugLog);
    }

    /**<summary>StringEventObserver listener</summary> */
    public void AddListener(string key, Action<object> eventCallback, bool showDebugLog = false) {
        StringEventObserver.AddListener(key, eventCallback, showDebugLog);
    }

    /**<summary>StringEventObserver listener</summary> */
    public void AddListener(string key, Action eventCallback, bool showDebugLog = false) {
        StringEventObserver.AddListener(key, eventCallback, showDebugLog);
    }

    /**<summary>StringEventObserver listener</summary> */
    public void RemoveListener(string key, Action<object> eventCallback, bool showDebugLog = false) {
        StringEventObserver.RemoveListener(key, eventCallback, showDebugLog);
    }

    /**<summary>StringEventObserver listener</summary> */
    public void RemoveListener(string key, Action eventCallback, bool showDebugLog = false) {
        StringEventObserver.RemoveListener(key, eventCallback, showDebugLog);
    }

    /** <summary> Remove ALL callback listener by `key`. Be carefully, use at OnDestroy only to free RAM. </summary> */
    public void RemoveListener(string key) {
        StringEventObserver.RemoveListener(key);
    }
}
#endif // STRING_OBSERVER