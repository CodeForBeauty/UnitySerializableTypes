using UnityEngine;

namespace SerializableTypes.Examples {

    public class StackShow : MonoBehaviour {
        [Header("View stacks in editor")]
        [SerializeField] private SerializableStack<int>  _intStack;

        [SerializeField] private SerializableStack<string> _stringStack;
    }

}
