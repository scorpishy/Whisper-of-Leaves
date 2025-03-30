using UnityEngine;

namespace Game.Infrastructure.AudioScope
{
    [CreateAssetMenu(fileName = "SFXConfig", menuName = "Configs/Audio/SFX Config", order = 1)]
    public class GardenSFXConfig : ScriptableObject
    {
        [field: SerializeField] public AudioClip FruitGrownClip { get; private set; }
        [field: SerializeField] public AudioClip PlantWitheredClip { get; private set; }
    }
}