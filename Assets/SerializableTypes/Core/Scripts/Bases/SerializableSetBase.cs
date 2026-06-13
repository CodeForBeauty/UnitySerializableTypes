using System.Collections.Generic;

namespace SerializableTypes {

    abstract public class SerializableSetBase<T> {
        readonly public HashSet<T> Set = new();
    }

}
