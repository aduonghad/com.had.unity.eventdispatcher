using System;

namespace had.eventdispatcher {
    /** <summary> Send multi params to dispatcher </summary>*/
    public class ParamsEventObserver : EventObserver<Type, IEventParams> {
        public void AddListener<T>(Action<T> eventCallback, bool showDebugLog = false) where T : IEventParams {
            Action<IEventParams> action = (param) => { eventCallback.Invoke((T)param); };
            base.AddListener(typeof(T), action, showDebugLog);
        }

        public void RemoveListener<T>(Action<T> eventCallback, bool showDebugLog = false) where T : IEventParams {
            Action<IEventParams> action = (param) => { eventCallback.Invoke((T)param); };
            base.RemoveListener(typeof(T), action, showDebugLog);
        }

        public void AddListener<T>(Action eventCallback, bool showDebugLog = false) where T : IEventParams {
            Action<IEventParams> action = (param) => { eventCallback.Invoke(); };
            base.AddListener(typeof(T), action, showDebugLog);
        }

        public void RemoveListener<T>(Action eventCallback, bool showDebugLog = false) where T : IEventParams {
            Action<IEventParams> action = (param) => { eventCallback.Invoke(); };
            base.RemoveListener(typeof(T), action, showDebugLog);
        }

        public void RemoveListener<T>() where T : IEventParams {
            base.RemoveListener(typeof(T));
        }

        public void Dispatch<T>(bool showDebugLog = false) where T : IEventParams {
            base.Dispatch(typeof(T), null, showDebugLog);
        }

        public void Dispatch<T>(T param, bool showDebugLog = false) where T : IEventParams {
            base.Dispatch(typeof(T), param, showDebugLog);
        }
    }
}

/** <summary> Send multi params to dispatcher </summary>*/
public interface IEventParams {
}