using UnityEngine;

namespace SerializableTypes.Examples {

    public class QueueShow : MonoBehaviour {
        [Header("View Queues in editor")]
        [SerializeField] private SerializableQueue<int> _intQueue;

        [SerializeField] private SerializableQueue<string> _stringQueue;

        [Header("Queue of [SerializeReference]")]
        [SerializeField] private SerializableQueue<RefWrapper<EffectBase>> _effectQueue;


        public void EmptyAndPrintIntQueue() {
            for (int i = _intQueue.Count - 1; i >= 0; i--) {
                Debug.Log(_intQueue.Dequeue());
            }
        }

        public void EnqueueRandomInt() {
            _intQueue.Enqueue(Random.Range(int.MinValue, int.MaxValue));
        }

        public void EmptyAndApplyEffectQueue() {
            for (int i = _effectQueue.Count - 1; i >= 0; i--) {
                _effectQueue.Dequeue().Value?.Apply(gameObject);
            }
        }
    }

}
