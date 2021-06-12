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
                    audioService.PlaySFX("reverb_small", this.gameObject);
                    audioService.PlaySFX("player_enter", this.gameObject);
                    break;
                case ReverbLevels.Medium:
                    audioService.PlaySFX("reverb_medium", this.gameObject);
                    audioService.PlaySFX("player_enter", this.gameObject);
                    break;
                case ReverbLevels.Large:
                    audioService.PlaySFX("reverb_large", this.gameObject);
                    audioService.PlaySFX("player_enter", this.gameObject);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IAudioService audioService = ServiceLocator.GetService<IAudioService>();

        if (other.CompareTag("Player"))
        {
            audioService.PlaySFX("reverb_off", this.gameObject);
            audioService.PlaySFX("player_exit", this.gameObject);

        }
    }

}
