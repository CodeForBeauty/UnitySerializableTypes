using UnityEditor;

namespace SerializableTypes.Editor {

    /// <summary>
    /// Duplicate of the SerializableDictionaryDrawer for reference dictionary.
    /// </summary>
    [CustomPropertyDrawer(typeof(SerializableDictionaryRef<,>))]
    public class SerializableDictionaryRefDrawer : SerializableDictionaryDrawer {
        
    }

}
