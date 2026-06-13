using System.Collections.Generic;
using UnityEngine;

namespace SerializableTypes {

    /// <summary>
    /// Base class for SerializableDictionary implementations.
    /// </summary>
    /// <typeparam name="TKey">Key type for a Dictionary</typeparam>
    /// <typeparam name="TValue">Value type for a Dictionary</typeparam>
    abstract public class SerializableDictionaryBase<TKey, TValue> {
        readonly public Dictionary<TKey, TValue> Dict = new();

        [SerializeField] protected bool hasDuplicates = false;
    }

}
