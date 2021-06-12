using System.Collections;
using System.Collections.Generic;
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
            Debug.Log("reverberate!");
            switch (level)
            {
                case ReverbLevels.None:
                    AkSoundEngine.PostEvent("reverb_off", this.gameObject);
                    break;
                case ReverbLevels.Small:
                    AkSoundEngine.PostEvent("reverb_small", this.gameObject);
                    break;
                case ReverbLevels.Medium:
                    AkSoundEngine.PostEvent("reverb_medium", this.gameObject);
                    break;
                case ReverbLevels.Large:
                    AkSoundEngine.PostEvent("reverb_large", this.gameObject);
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
        }
    }

}