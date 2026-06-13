using System.Collections.Generic;
using UnityEngine;


namespace SerializableTypes {

    /// <summary>
    /// Dictionary wrapper with elements serialized as values.
    /// </summary>
    /// <typeparam name="TKey">Key type for a Dictionary</typeparam>
    /// <typeparam name="TVal">Value type for a Dictionary</typeparam>
    [System.Serializable]
    public class SerializableDictionary<TKey, TVal> : ISerializationCallbackReceiver {
        /// <summary>
        /// Key-Value pair with boolean mark for duplicates.
        /// </summary>
        [System.Serializable]
        public class KeyValue {
            public TKey Key;
            public TVal Value;

            public bool isDuplicate;
        }

        readonly public Dictionary<TKey, TVal> Dict = new();

        [SerializeField] protected bool hasDuplicates = false;

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
