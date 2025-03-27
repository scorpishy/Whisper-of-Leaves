using UnityEngine;

namespace Game.EntryPoint.Configs
{
    [CreateAssetMenu(fileName = "SFXConfig", menuName = "Configs/Audio/SFX Config", order = 1)]
    public class PlantSFXConfig : ScriptableObject
    {
        [field: SerializeField] public AudioClip FruitGrownClip { get; private set; }
        [field: SerializeField] public AudioClip PlantWitheredClip { get; private set; }
    }
}