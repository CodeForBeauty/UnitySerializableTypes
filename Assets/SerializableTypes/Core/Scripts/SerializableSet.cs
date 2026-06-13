using System.Collections.Generic;
using UnityEngine;

namespace SerializableTypes {

    /// <summary>
    /// HashSet wrapper with elements serialized as values.
    /// </summary>
    /// <typeparam name="T">Elements type for a HashSet</typeparam>
    [System.Serializable]
    public class SerializableSet<T> : SerializableSetBase<T>, ISerializationCallbackReceiver {
        [SerializeField] private List<T> _set;

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize() {
            Set.Clear();

            foreach (T el in _set) {
                Set.Add(el);
            }
        }
    }

}
