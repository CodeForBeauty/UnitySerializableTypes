using UnityEngine;

namespace SerializableTypes.Examples {

    public class EffectDamage : EffectBase {
        [Min(1)]
        [SerializeField] private int _damage = 5;

        public override void Apply(GameObject obj) {
            Debug.Log($"GameObject {obj.name} dealt {_damage} damage");
        }
    }

}
