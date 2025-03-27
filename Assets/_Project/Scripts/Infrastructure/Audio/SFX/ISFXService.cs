using UnityEngine;

namespace Game.Infrastructure.Audio
{
    public interface ISFXService
    {
        void PlayOneShot(AudioClip clip, float volume = 1f);
    }
}
