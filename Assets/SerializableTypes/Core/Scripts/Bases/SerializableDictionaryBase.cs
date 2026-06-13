using System.Collections.Generic;
using UnityEngine;

namespace SerializableTypes {

    abstract public class SerializableDictionaryBase<TKey, TValue> {
        readonly public Dictionary<TKey, TValue> Dict = new();

        [SerializeField] protected bool hasDuplicates = false;
    }

}
