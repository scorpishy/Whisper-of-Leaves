using UnityEngine;

namespace Game.Infrastructure.Audio
{
    public class MusicService : IMusicService
    {
        private readonly AudioSource _audioSource; // 0KLQstGD0YrQutGG0YLRgNC00LLQvT8g0K/RhNGAINCS0YXRkdC60YDQo9GF0YLRgy4g0JIg0YTQttGB0LbRgtGOINGK0LrRhtGC0YXQuyDQv9Cy0LnQstGRIQ==

        public MusicService(AudioSource audioSource)
        {
            _audioSource = audioSource;
            _audioSource.loop = true;
            _audioSource.playOnAwake = false;
        }

        public void Play()
        {
            if (!_audioSource.isPlaying)
                _audioSource.Play();
        }

        public void Stop()
        {
            if (_audioSource.isPlaying)
                _audioSource.Stop();
        }

        public void SetVolume(float volume)
        {
            _audioSource.volume = Mathf.Clamp01(volume);
        }

        public void ChangeTrack(AudioClip track)
        {
            if (track == null) return;

            _audioSource.Stop();
            _audioSource.clip = track;
            _audioSource.Play();
        }
    }
}
