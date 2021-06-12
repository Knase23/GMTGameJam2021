using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;

public enum ReverbLevels { None, Small, Medium, Large };

[RequireComponent(typeof(BoxCollider))]
public class Reverb : MonoBehaviour
{
    BoxCollider col;
    public ReverbLevels level;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
        col.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IAudioService audioService = ServiceLocator.GetService<IAudioService>();
            switch (level)
            {
                case ReverbLevels.None:
                    audioService.PlaySFX("reverb_off", this.gameObject);
                    break;
                case ReverbLevels.Small:
                    AkSoundEngine.PostEvent("reverb_small", this.gameObject);
                    AkSoundEngine.PostEvent("player_enter", this.gameObject);
                    break;
                case ReverbLevels.Medium:
                    AkSoundEngine.PostEvent("reverb_medium", this.gameObject);
                    AkSoundEngine.PostEvent("player_enter", this.gameObject);
                    break;
                case ReverbLevels.Large:
                    AkSoundEngine.PostEvent("reverb_large", this.gameObject);
                    AkSoundEngine.PostEvent("player_enter", this.gameObject);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AkSoundEngine.PostEvent("reverb_off", this.gameObject);
            AkSoundEngine.PostEvent("player_exit", this.gameObject);

        }
    }

}
