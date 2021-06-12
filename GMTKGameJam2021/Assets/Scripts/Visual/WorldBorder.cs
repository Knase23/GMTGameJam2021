using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBorder : MonoBehaviour
{
    private Color noAlpha;


    public Boolean fadeInFlag;

    public List<Renderer> fadeMaterials;
    public List<SpriteRenderer> FadeSprites;

    void Start()
    {
        noAlpha = new Color(1, 1, 1, 0);
     

    }

    // Update is called once per frame
    void Update()
    {

        foreach (var item in fadeMaterials)
        {
            item.material.color = Color.Lerp(item.material.color, fadeInFlag.flag ? Color.white : noAlpha, Time.deltaTime / 2f);
        }

        foreach (var item in FadeSprites)
        {
            item.color = Color.Lerp(item.color, fadeInFlag.flag ? Color.white : noAlpha, Time.deltaTime / 2f);
        }



    }



}
