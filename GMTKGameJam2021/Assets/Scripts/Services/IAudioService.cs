using UnityEngine;
public interface IAudioService
{
    void PlayMusic(string musicName);
    void PlaySFX(string codeName);
    void PlaySFX(string clipName, GameObject gameObject);
    void StopAll();
    void Stop(StopEvents stopEvent);
    void SetVolume(MixerName mixer, float volume);
}

public enum MusicState
{
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    
}

public enum StopEvents
{
    MUSIC,
    SFX,
    VOICE,
    ALL,
    ALL_WITH_FADE,
    All_VICTORY_SCREEN,
}
public enum MixerName
{
    MASTER,
    SFX,
    MUSIC,
    VOICE
}