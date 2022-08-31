using System;
using System.Collections.Generic;

namespace had.eventdispatcher {
    public class EventObserver<K, V> {
        private readonly Dictionary<K, Dictionary<int, Action<V>>> observerDictionary = new Dictionary<K, Dictionary<int, Action<V>>>();

        public void AddListener(K key, Action<V> eventCallback, bool showDebugLog = false) {
            var hashCode = eventCallback.GetHashCode();
            Action<V> action = eventCallback.Invoke;
            AddListener(key, hashCode, action, showDebugLog);
        }

        public void AddListener(K key, Action eventCallback, bool showDebugLog = false) {
            var hashCode = eventCallback.GetHashCode();
            Action<V> action = _object => { eventCallback.Invoke(); };
            AddListener(key, hashCode, action, showDebugLog);
        }

        public void RemoveListener(K key, Action<V> eventCallback, bool showDebugLog = false) {
            RemoveByHashCode(key, eventCallback.GetHashCode(), showDebugLog);
        }

        public void RemoveListener(K key, Action eventCallback, bool showDebugLog = false) {
            RemoveByHashCode(key, eventCallback.GetHashCode(), showDebugLog);
        }

        /** <summary> Remove ALL callback listener by `key`. Be carefully, use at OnDestroy only to free RAM. </summary> */
        public void RemoveListener(K key) {
            RemoveByKey(key);
        }

        /** <summary> Remove all listener. Be carefully, use at OnDestroy or OnApplicationQuiting only to free RAM. </summary> */
        public void RemoveAllListener() {
            observerDictionary.Clear();
        }

        private void AddListener(K key, int hashCode, Action<V> action, bool showDebugLog = false) {
            if(showDebugLog) {
                UnityEngine.Debug.LogFormat("[EventDispatcher({1})] Register Key: {0}", key, typeof(K));
            }

            Dictionary<int, Action<V>> value;
            if(!observerDictionary.TryGetValue(key, out value)) {
                value = new Dictionary<int, Action<V>>();
                observerDictionary[key] = value;
            }

            value[hashCode] = action;
        }


        private void RemoveByHashCode(K key, int hashCode, bool showDebugLog = false) {
            if(showDebugLog) {
                UnityEngine.Debug.LogFormat("[EventDispatcher({1})] UnRegister Key: {0}", key, typeof(K));
            }

            Dictionary<int, Action<V>> value;
            if(observerDictionary.TryGetValue(key, out value)) {
                value.Remove(hashCode);
            }
        }

        private void RemoveByKey(K key, bool showDebugLog = false) {
            if(showDebugLog) {
                UnityEngine.Debug.LogFormat("[EventDispatcher({1})] UnRegister All of Key: {0}", key, typeof(K));
            }
            observerDictionary.Remove(key);
        }

        public void Dispatch(K key, V obj = default(V), bool showDebugLog = false) {
            Dictionary<int, Action<V>> value;
            if(observerDictionary.TryGetValue(key, out value)) {
                var valueCollection = value.Values;
#if !PRODUCTION_BUILD
                if(showDebugLog) {
                    UnityEngine.Debug.LogFormat("[EventDispatcher({3})] Dispatch total_events={2}, key={0}, action=[{1}])", key, obj, valueCollection.Count, typeof(K));
                }
#endif
                foreach(var caller in valueCollection) {
                    caller(obj);
                }
            }
            else {
                if(showDebugLog) {
                    UnityEngine.Debug.LogFormat("[EventDispatcher{2}] No dispatch to send: (key:{0}, action:{1})", key, obj, typeof(K));
                }
            }
        }
    }
}