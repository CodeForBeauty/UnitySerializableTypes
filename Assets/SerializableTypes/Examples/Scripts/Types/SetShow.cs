using UnityEngine;


namespace SerializableTypes.Examples {

    public class SetShow : MonoBehaviour {
        [Header("View sets in editor")]
        [SerializeField] private SerializableSet<int> _intSet;

        [SerializeField] private SerializableSet<string> _stringSet;


        public void PrintIntSet() {
            foreach (int val in _intSet.Data) {
                Debug.Log(val);
            }
        }

        public void AddRandomInt() {
            _intSet.Add(Random.Range(int.MinValue, int.MaxValue));
        }
    }

}
