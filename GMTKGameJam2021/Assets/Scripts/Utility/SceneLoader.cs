using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int additiveSceneIndex;

    public List<string> ScenesToLoad = new List<string>();
    
    // Start is called before the first frame update
    void Start()
    {
        List<Scene> scenesToLoad = new List<Scene>();
        foreach (string s in ScenesToLoad)
        {
            scenesToLoad.Add(SceneManager.GetSceneByName(s));
        }
        foreach (Scene scene in scenesToLoad)
        {
            if (scene.isLoaded)
            {
                Debug.Log(scene.name +" already loaded");
                continue;
            }
            SceneManager.LoadScene(scene.buildIndex, LoadSceneMode.Additive);
        }
    }
}