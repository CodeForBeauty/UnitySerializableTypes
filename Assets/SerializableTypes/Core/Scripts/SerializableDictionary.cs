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

        readonly private Dictionary<TKey, TVal> _dict = new();
        public IReadOnlyDictionary<TKey, TVal> Dict => _dict;


        [SerializeField] private List<KeyValue> _dictionary;
        [SerializeField] protected bool hasDuplicates = false;

        #region Editing
        /// <summary>
        /// Tries to add key value pair to the Dictionary.
        /// </summary>
        /// <param name="key">Key for the addition</param>
        /// <param name="value">Value for the addition</param>
        /// <returns>false if failed, true if added</returns>
        public bool Add(TKey key, TVal value) {
            if (_dict.ContainsKey(key)) {
                return false;
            }

            _dict.Add(key, value);
            _dictionary.Add(new KeyValue() { Key = key, Value = value });
            return true;
        }

        /// <summary>
        /// Tries to remove the key from dictionary.
        /// Removes all of the occurences in a serialized list.
        /// </summary>
        /// <param name="key">Key to remove</param>
        /// <returns>false if key doesn't exist, true if key is removed</returns>
        public bool RemoveKey(TKey key) {
            if (!_dict.ContainsKey(key)) {
                return false;
            }

            _dict.Remove(key);
            for (int i = _dictionary.Count - 1; i >= 0; i--) {
                if (_dictionary[i].Key.Equals(key)) {
                    _dictionary.RemoveAt(i);
                }
            }
            return true;
        }
        #endregion

        #region Serialization
        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize() {
            _dict.Clear();
            hasDuplicates = false;

            foreach (KeyValue kv in _dictionary) {
                if (_dict.ContainsKey(kv.Key)) {
                    kv.isDuplicate = true;
                    hasDuplicates = true;
                }
                else {
                    kv.isDuplicate = false;
                    _dict.Add(kv.Key, kv.Value);
                }
            }
        }
        #endregion
    }

}
