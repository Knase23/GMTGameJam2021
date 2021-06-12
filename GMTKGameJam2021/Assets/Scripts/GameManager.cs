using System;
using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _singeltonInstance;

    private void Awake()
    {
        if (_singeltonInstance)
        {
            Destroy(gameObject);
        }
        else
        {
            _singeltonInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("reverb_off", this.gameObject);
        ServiceLocator.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ServiceLocator.GetService<IAudioService>().PlaySFX("test1");
        }
    }
}
