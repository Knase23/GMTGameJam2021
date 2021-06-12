using UnityEngine;

namespace Global.ServiceLocators.AudioServices
{
    public class NullAudioService : IAudioService
    {
        public void Stop(StopEvents stopEvent)
        {
            
        }

        public void PauseAll()
        {
        
        }

        public void PlayMusic(string musicName)
        {
        
        }

        public void PlaySFX(string clipName)
        {
       
        }

        public void PlaySFX(string clipName, GameObject gameObject)
        {

        }

        public void ResumeAll()
        {
        
        }

        public void SetVolume(MixerName mixer, float volume)
        {
        
        }

        public void SetRTPC(string name, float value)
        {
            
        }

        public void StopAll()
        {
        
        }
    }
}
