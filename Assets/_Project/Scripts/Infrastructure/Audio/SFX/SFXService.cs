using UnityEngine;

namespace Game.Infrastructure.Audio
{
    public class SFXService : ISFXService
    {
        private readonly AudioSource _sfxSource;

        public SFXService(AudioSource sfxSource)
        {
            _sfxSource = sfxSource;
            _sfxSource.playOnAwake = false;
        }

        public void PlayOneShot(AudioClip clip, float volume = 1f)
        {
            if (clip == null) return;
            _sfxSource.PlayOneShot(clip, Mathf.Clamp01(volume));
        }
    }
}
