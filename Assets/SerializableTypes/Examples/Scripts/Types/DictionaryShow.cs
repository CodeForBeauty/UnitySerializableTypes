using UnityEngine;

namespace SerializableTypes.Examples {

    public class DictionaryShow : MonoBehaviour {
        [Header("Dictionary views")]
        [SerializeField] private SerializableDictionary<string, string> _stringTest;

        [Header("Dictionary with [SerializeReference]")]
        [SerializeField] private SerializableDictionaryRef<string, EffectBase> _refTest;

        private void Start() {
            foreach (var kv in _stringTest.Dict) {
                print($"{kv.Key} - {kv.Value}");
            }
        }
    }

}
