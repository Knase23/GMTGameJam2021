using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private static ScreenShake _instance; 
    
    private float _shakeStrength;
    private float _shakeTimer;
    
    [Tooltip("Set this so multiple objects shaking at the same time won't shake the same.")]
    public Vector2 seed;

    [Range(0.01f, 50f)] public float speed;

    [Tooltip("We won't move further than this distance from neutral.")] [Range(0.01f, 10f)]
    public float maxMagnitude;

    [Tooltip("0 follows _Direction exactly. 3 mostly ignores _Direction and shakes in all directions.")] [Range(0f, 3f)]
    public float noiseMagnitude;

    public Vector2 direction = Vector2.up;

    private float _fadeOut = 1f;
    // Start is called before the first frame update

    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
        }
    }

    public static void Shake(float timer)
    {
        if (_instance)
        {
            _instance._shakeTimer = timer ;
        }
    }
    public static void Shake(float timer,Vector2 seed = new Vector2(), float speed = 1, float maxMagnitude = 1, float noiseMagnitude = 1, Vector2 direction = new Vector2())
    {
        if (_instance)
        {
            _instance.seed = seed;
            _instance.speed = speed;
            _instance.maxMagnitude = maxMagnitude;
            _instance.noiseMagnitude = noiseMagnitude;
            _instance.direction = direction;
            _instance._shakeTimer = timer;
        }
    }
    
    private void Shake(float str, float time)
    {
        _shakeStrength = str;
        _shakeTimer = time;
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Shake(1,0.5f);
        }
        
        
        _shakeTimer -= Time.unscaledDeltaTime; 
        if (_shakeTimer < 0) _shakeTimer = 0;
        //Right now it does not do a fade out!
        if (_shakeTimer > 0)
        {
            
            //This code makes the shaking happen!
            float sin = Mathf.Sin(speed * (seed.x + seed.y + Time.time));
            Vector2 noiseDirection = this.direction + GetNoise();
            noiseDirection.Normalize();
            Vector2 delta = noiseDirection * sin;
            transform.localPosition =  delta * (maxMagnitude * _fadeOut);
            //CameraOffset.positionOffset = delta * (maxMagnitude * _fadeOut);
        }
        else
        {
            transform.localPosition = Vector3.zero;
        }
    }
    private Vector2 GetNoise()
    {
        float time = Time.time;
        return noiseMagnitude * new Vector2(
            Mathf.PerlinNoise(seed.x, time) - 0.5f,
            Mathf.PerlinNoise(seed.y, time) - 0.5f);
    }
}
