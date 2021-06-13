using System;
using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _singeltonInstance;

    public Boolean bridgeCondition;
    
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
        ServiceLocator.Initialize();
        IAudioService audioService = ServiceLocator.GetService<IAudioService>();
        audioService.PlayMusic("bgm_main");
        audioService.PlayMusic("reverb_off");
    }
    public void OnFollowerAmount(int amount)
    {
        if (amount >= 3)
        {
            
            bridgeCondition.flag = true;
        }
         
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            //ServiceLocator.GetService<IAudioService>().PlaySFX("test1");
        }
    }

}
