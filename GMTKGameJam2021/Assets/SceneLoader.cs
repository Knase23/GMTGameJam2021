using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int additiveSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != additiveSceneIndex)
            SceneManager.LoadScene(additiveSceneIndex, LoadSceneMode.Additive);
    }
}