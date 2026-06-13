using UnityEngine;


namespace SerializableTypes.Examples {

    public class SetShow : MonoBehaviour {
        [Header("View sets in editor")]
        [SerializeField] private SerializableSet<int> _intSet;

        [SerializeField] private SerializableSet<string> _stringSet;
    }

}
