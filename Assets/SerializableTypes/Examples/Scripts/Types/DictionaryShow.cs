using UnityEngine;

namespace SerializableTypes.Examples {

    public class DictionaryShow : MonoBehaviour {
        [Header("Dictionary views")]
        [SerializeField] private SerializableDictionary<string, string> _stringTest;

        [Header("Dictionary with [SerializeReference]")]
        [SerializeField] private SerializableDictionary<string, RefWrapper<EffectBase>> _refTest;

        public void PrintStringDictionary() {
            foreach (var kv in _stringTest.Data) {
                Debug.Log($"{kv.Key} - {kv.Value}");
            }
        }

        public void FireReferences() {
            foreach (var kv in _refTest.Data) {
                Debug.Log(kv.Key);
                kv.Value.Value.Apply(gameObject);
            }
        }
    }

}
