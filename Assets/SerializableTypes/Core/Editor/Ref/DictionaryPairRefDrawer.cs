using UnityEditor;

namespace SerializableTypes.Editor {

    /// <summary>
    /// Duplicate of the DictionaryPairDrawer for reference dictionary KeyValue pair.
    /// </summary>
    [CustomPropertyDrawer(typeof(SerializableDictionaryRef<,>.KeyValue))]
    public class DictionaryPairRefDrawer : DictionaryPairDrawer {
        
    }

}
