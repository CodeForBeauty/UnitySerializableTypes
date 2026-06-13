using UnityEngine;


namespace SerializableTypes.Examples {

    public class SetShow : MonoBehaviour {
        [SerializeField] private SerializableSet<int> _intSet;

        [SerializeField] private SerializableSet<string> _stringSet;
    }

}
