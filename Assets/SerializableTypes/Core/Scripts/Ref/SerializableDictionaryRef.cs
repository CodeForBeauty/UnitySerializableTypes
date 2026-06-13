using System.Collections.Generic;
using UnityEngine;

namespace SerializableTypes {

    /// <summary>
    /// Dictionary wrapper with Keys serialized as values and Values serialized as references
    /// </summary>
    /// <typeparam name="TKey">Key type for a Dictionary</typeparam>
    /// <typeparam name="TVal">Value type for a Dictionary. Only reference types allowed(no structs).</typeparam>
    [System.Serializable]
    public class SerializableDictionaryRef<TKey, TVal> : SerializableDictionaryBase<TKey, TVal>, ISerializationCallbackReceiver {
        /// <summary>
        /// Key-Value pair with boolean mark for duplicates.
        /// </summary>
        [System.Serializable]
        public class KeyValue {
            public TKey Key;
            [SerializeReference, SubclassSelector]
            public TVal Value;

            public bool isDuplicate;
        }

        [SerializeField] private List<KeyValue> _dictionary;

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize() {
            Dict.Clear();
            hasDuplicates = false;

            foreach (KeyValue kv in _dictionary) {
                if (Dict.ContainsKey(kv.Key)) {
                    kv.isDuplicate = true;
                    hasDuplicates = true;
                }
                else {
                    kv.isDuplicate = false;
                    Dict.Add(kv.Key, kv.Value);
                }
            }
        }
    }

}
