using UnityEditor;
using UnityEngine;

namespace SerializableTypes.Editor {

    [CustomPropertyDrawer(typeof(SerializableDictionaryRef<,>.KeyValue))]
    public class DictionaryPairRefDrawer : DictionaryPairDrawer {
        
    }

}
