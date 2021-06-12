﻿using UnityEngine;

namespace Global.ServiceLocators.AudioServices
{
    public class WwiseAudioService : IAudioService
    {
        public static GameObject objRef;
        
        public WwiseAudioService()
        {
            objRef = new GameObject("Wwise gameObject Reference");
        }

        public void PlayMusic(string musicName)
        {
            AkSoundEngine.PostEvent(musicName, objRef,(uint)AkCallbackType.AK_MusicSyncUserCue,MusicUserCue,null);
        }

        private void MusicUserCue(object in_cookie, AkCallbackType in_type, AkCallbackInfo in_info)
        {
            if (in_info is AkMusicSyncCallbackInfo callbackInfo)
            {

            }
            
        }

        public void PlaySFX(string clipName)
        {
            AkSoundEngine.PostEvent(clipName, objRef);
        }

        public void StopAll()
        {
            AkSoundEngine.StopAll();
        }

        public void Stop(StopEvents stopEvent)
        {
            string code = "stop_" + stopEvent.ToString().ToLower();
            AkSoundEngine.PostEvent(code, objRef);
        }
        
        public void PlaySFX(string clipName, GameObject gameObject)
        {
            AkSoundEngine.PostEvent(clipName, gameObject);
        }

        public void SetRTPC(string name, float value)
        {
            AkSoundEngine.SetRTPCValue(name, value);
        }
        
        
        public void SetVolume(MixerName mixer, float volume)
        {
            switch (mixer)
            {
                case MixerName.MASTER:
                    AkSoundEngine.SetRTPCValue("MASTER_VOLUME", volume);
                    break;
                case MixerName.SFX:
                    AkSoundEngine.SetRTPCValue("SFX_VOLUME", volume);
                    break;
                case MixerName.MUSIC:
                    AkSoundEngine.SetRTPCValue("MUSIC_VOLUME", volume);
                    break;
                case MixerName.VOICE:
                    AkSoundEngine.SetRTPCValue("VOX_VOLUME", volume);
                    break;
                default:
                    break;
            }
        }
    }
}