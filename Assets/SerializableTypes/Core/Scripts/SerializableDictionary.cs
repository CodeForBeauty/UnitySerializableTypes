using System.Collections.Generic;
using UnityEngine;


namespace SerializableTypes {

    [System.Serializable]
    public class SerializableDictionary<TKey, TVal> : SerializableDictionaryBase<TKey, TVal>, ISerializationCallbackReceiver {
        [System.Serializable]
        public class KeyValue {
            public TKey Key;
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
