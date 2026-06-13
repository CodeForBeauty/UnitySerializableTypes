
using UnityEngine;

namespace SerializableTypes.Examples {

    [System.Serializable]
    abstract public class EffectBase {
        abstract public void Apply(GameObject obj);
    }

}
