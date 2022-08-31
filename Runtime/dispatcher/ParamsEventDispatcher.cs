/** <summary> 
 * Uncomment the define PARAMS_OBSERVER to use EventParams key in EventDispatcher
 * </summary> */

#define PARAMS_OBSERVER


#if PARAMS_OBSERVER
using had.eventdispatcher;
using System;
using UnityEngine;

public partial class EventDispatcher : Component {
    private ParamsEventObserver paramsEventObserver;
    private ParamsEventObserver ParamsEventObserver {
        get {
            if (paramsEventObserver != null) return paramsEventObserver;
            paramsEventObserver = new ParamsEventObserver();
            return paramsEventObserver;
        }
    }

#region Params Generic Key
    /**<summary>ParamsEventObserver listener</summary> */
    public void Dispatch<T>(bool showDebugLog = false) where T : IEventParams {
        ParamsEventObserver.Dispatch<T>(showDebugLog);
    }

    /**<summary>ParamsEventObserver listener</summary> */
    public void Dispatch<T>(T eventParams, bool showDebugLog = false) where T : IEventParams {
        ParamsEventObserver.Dispatch<T>(eventParams, showDebugLog);
    }
    
    /**<summary>ParamsEventObserver listener</summary> */
    public void AddListener<T>(Action<T> eventCallback, bool showDebugLog = false) where T : IEventParams {
        ParamsEventObserver.AddListener<T>(eventCallback);
    }

    /**<summary>ParamsEventObserver listener</summary> */
    public void AddListener<T>(Action eventCallback, bool showDebugLog = false) where T : IEventParams {
        ParamsEventObserver.AddListener<T>(eventCallback);
    }

    /**<summary>ParamsEventObserver listener</summary> */
    public void RemoveListener<T>(Action<T> eventCallback, bool showDebugLog = false) where T : IEventParams {
        ParamsEventObserver.RemoveListener(eventCallback);
    }

    /**<summary>ParamsEventObserver listener</summary> */
    public void RemoveListener<T>(Action eventCallback, bool showDebugLog = false) where T : IEventParams {
        ParamsEventObserver.RemoveListener<T>(eventCallback);
    }

    /** <summary> Remove ALL callback listener by `key`. Be carefully, use at OnDestroy only to free RAM. </summary> */
    public void RemoveListener<T>() where T : IEventParams {
        ParamsEventObserver.RemoveListener<T>();
    }
#endregion
}
#endif // PARAMS_OBSERVER
