using UnityEngine;

namespace Global.ServiceLocators.AudioServices
{
    /// <summary>
    /// Audio service that prints debug logs instead of playing sounds.
    /// </summary>
    public class DebugAudioService : IAudioService
    {
        public void Stop(StopEvents stopEvent)
        {
            Debug.Log("stop_" + stopEvent.ToString().ToLower());
        }

        public void PauseAll()
        {
            Debug.Log("Pause All sound"); 
        }

        public void PlayMusic(string musicName)
        {
            Debug.Log($"Play music: {musicName}");
        }

        public void PlaySFX(string clipName)
        {
            Debug.Log($"Play SFX: {clipName}");
        }

        public void PlaySFX(string clipName, GameObject gameObject)
        {
            Debug.Log($"Play SFX: {clipName} + {gameObject}");
        }

        public void ResumeAll()
        {
            Debug.Log("Resume All Sound");
        }

        public void SetVolume(MixerName mixer, float volume)
        {
            //Debug.Log($" {mixer} volume set to : {volume}");
        }

        public void SetRTPC(string name, float value)
        {
            
        }

        public void StopAll()
        {
            Debug.Log("Stop All Sound");
        }

    }
}
