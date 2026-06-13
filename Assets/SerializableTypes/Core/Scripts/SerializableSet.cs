using System.Collections.Generic;
using UnityEngine;

namespace SerializableTypes {

    [System.Serializable]
    public class SerializableSet<T> : SerializableSetBase<T>, ISerializationCallbackReceiver {
        [SerializeField] private List<T> _set;

        public void OnBeforeSerialize() {
            _set.Clear();

            foreach (T el in Set) {
                _set.Add(el);
            }
        }

        public void OnAfterDeserialize() {
            Set.Clear();

            foreach (T el in _set) {
                Set.Add(el);
            }
        }
    }

}
