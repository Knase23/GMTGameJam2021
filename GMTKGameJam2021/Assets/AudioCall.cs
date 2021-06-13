using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;

public class AudioCall : MonoBehaviour
{
    public void PlayAudio(string eventName)
    {
        ServiceLocator.GetService<IAudioService>().PlaySFX(eventName);
    }
}
