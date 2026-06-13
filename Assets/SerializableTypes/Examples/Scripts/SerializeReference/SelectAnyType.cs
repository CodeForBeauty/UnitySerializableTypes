using UnityEngine;

namespace SerializableTypes.Examples {

    public class SelectAnyType : MonoBehaviour {
        [Header("Select object of any type")]
        [SerializeReference, SubclassSelector] private object _obj;
    }

}
