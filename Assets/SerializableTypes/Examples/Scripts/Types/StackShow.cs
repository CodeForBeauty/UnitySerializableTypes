using UnityEngine;

namespace SerializableTypes.Examples {

    public class StackShow : MonoBehaviour {
        [Header("View stacks in editor")]
        [SerializeField] private SerializableStack<int>  _intStack;

        [SerializeField] private SerializableStack<string> _stringStack;

        public void EmptyAndPrintIntStack() {
            for (int i = _intStack.Count - 1; i >= 0; i--) {
                Debug.Log(_intStack.Pop());
            }
        }

        public void PushRandomInt() {
            _intStack.Push(Random.Range(int.MinValue, int.MaxValue));
        }
    }

}
