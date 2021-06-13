using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public List<string> ScenesToLoad = new List<string>();
    
    void Start()
    {
        List<Scene> scenesToLoad = new List<Scene>();
        foreach (string s in ScenesToLoad)
        {
            scenesToLoad.Add( SceneManager.GetSceneByName(s));
        }
        
        for (int j = 0; j < ScenesToLoad.Count; j++)
        {
            if (scenesToLoad.Any(scene => scene.name == ScenesToLoad[j])) continue;
            SceneManager.LoadScene(ScenesToLoad[j], LoadSceneMode.Additive);
        }
    }
}