using UnityEngine;

namespace SerializableTypes.Examples {

    public class QueueShow : MonoBehaviour {
        [Header("View Queues in editor")]
        [SerializeField] private SerializableQueue<int> _intQueue;

        [SerializeField] private SerializableQueue<string> _stringQueue;

        [Header("Queue of [SerializeReference]")]
        [SerializeField] private SerializableQueue<RefWrapper<EffectBase>> _effectQueue;
    }

}
