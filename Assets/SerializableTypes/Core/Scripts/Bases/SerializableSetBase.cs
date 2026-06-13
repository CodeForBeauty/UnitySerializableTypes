using System.Collections.Generic;

namespace SerializableTypes {

    /// <summary>
    /// Base class for SerializableSet implementations.
    /// </summary>
    /// <typeparam name="T">Elements type for a HashSet</typeparam>
    abstract public class SerializableSetBase<T> {
        readonly public HashSet<T> Set = new();
    }

}
