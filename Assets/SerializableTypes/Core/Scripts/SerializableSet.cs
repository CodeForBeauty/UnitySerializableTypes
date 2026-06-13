using System.Collections.Generic;
using UnityEngine;

namespace SerializableTypes {

    /// <summary>
    /// HashSet wrapper with elements serialized as values.
    /// </summary>
    /// <typeparam name="T">Elements type for a HashSet</typeparam>
    [System.Serializable]
    public class SerializableSet<T> : ISerializationCallbackReceiver {
        readonly private HashSet<T> _data = new();
        public IReadOnlyCollection<T> Data => _data;

        [SerializeField] private List<T> _set;

        #region Editing
        /// <summary>
        /// Check if wrapped HashSet contains value.
        /// </summary>
        /// <param name="value">value to check</param>
        /// <returns>true if exists, false otherwise</returns>
        public bool Contains(T value) {
            return _data.Contains(value);
        }

        /// <summary>
        /// Try to add a value to the HashSet.
        /// </summary>
        /// <param name="value">value to add</param>
        /// <returns>false if value already exists, true if not</returns>
        public bool Add(T value) {
            if (_data.Contains(value)) {
                return false;
            }

            _data.Add(value);
            _set.Add(value);
            return true;
        }

        /// <summary>
        /// Try to remove a value from the HashSet.
        /// </summary>
        /// <param name="value">value to remove</param>
        /// <returns>true if removed successfully, false otherwise</returns>
        public bool Remove(T value) {
            if (!_data.Contains(value)) {
                return false;
            }

            _data.Remove(value);
            _set.RemoveAll(v => v.Equals(value));
            return true;
        }

        /// <summary>
        /// Clear the HashSet and serialized list.
        /// </summary>
        public void Clear() {
            _set.Clear();
            _data.Clear();
        }
        #endregion

        #region Serialization
        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize() {
            _data.Clear();
            
            foreach (T el in _set) {
                _data.Add(el);
            }
        }
        #endregion
    }

}
