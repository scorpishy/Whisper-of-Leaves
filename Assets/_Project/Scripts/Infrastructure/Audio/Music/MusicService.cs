using UnityEngine;

namespace Game.Infrastructure.AudioScope
{
    public class MusicService
    {
        private readonly AudioSource _audioSource;

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
