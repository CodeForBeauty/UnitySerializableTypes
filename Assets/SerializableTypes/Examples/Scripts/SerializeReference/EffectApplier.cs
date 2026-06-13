using System.Collections.Generic;
using UnityEngine;

namespace SerializableTypes.Examples {

    public class EffectApplier : MonoBehaviour {
        [Header("Calls Effect.Apply() on Start")]
        [SerializeReference, SubclassSelector] private EffectBase _effect;

        [Header("Incorrect use")]
        [SerializeField, SubclassSelector] private EffectApplier _test;

        [Header("List of references")]
        [SerializeReference, SubclassSelector] private List<EffectBase> _effectList;

        [Header("Reference wrapper class")]
        [SerializeField] private RefWrapper<EffectBase> _wrapperTest;

        private void Start() {
            _effect.Apply(gameObject);
        }
    }

}
