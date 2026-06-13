using UnityEngine;

namespace SerializableTypes.Examples {

    public class EffectStun : EffectBase {
        [Tooltip("Seconds")]
        [Min(0.1f)]
        [SerializeField] private float _stunTime = 2f;

        public override void Apply(GameObject obj) {
            Debug.Log($"GameObject {obj.name} stunned for {_stunTime} seconds");
        }
    }

}
