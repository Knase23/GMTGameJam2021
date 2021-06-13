using System;
using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        ServiceLocator.Initialize();
        IAudioService audioService = ServiceLocator.GetService<IAudioService>();
        audioService.PlayMusic("bgm_main");
        audioService.PlaySFX("reverb_off");
    }
    public void OnFollowerAmount(int amount)
    {
        if (amount >= 7)
        {
            
            bridgeCondition.flag = true;
        }
         
    }

    public void Restart()
    {
        SceneManager.LoadScene("ArenaInteractive", LoadSceneMode.Single);
    }

    public void GameOver()
    {
        if (!gameOver)
        {
            gameOver = true;
            //Do GameOverStuff!
            ServiceLocator.GetService<IAudioService>().PlayMusic("bgm_game_over");
        }

    }
    
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ServiceLocator.GetService<IAudioService>().Stop(StopEvents.SFX);
        }
        
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("Restart");
            Restart();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit Game");
#if !UNITY_EDITOR
            Application.Quit();
#endif
        }
    }

}
