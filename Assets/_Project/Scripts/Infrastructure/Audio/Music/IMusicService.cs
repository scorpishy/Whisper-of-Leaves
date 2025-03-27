using UnityEngine;

namespace Game.Infrastructure.Audio
{
    public interface IMusicService
    {
        void Play();
        void Stop();
        void SetVolume(float volume);
        void ChangeTrack(AudioClip clip);
    }
}
