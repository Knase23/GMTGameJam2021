using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;

public class SpinBuildingRaise : MonoBehaviour
{

    public Integer level;
    public ParticleSystem smoke;
    ParticleSystem.EmissionModule emission;

    private bool impact;
    // Start is called before the first frame update
    void Start()
    {
        emission = smoke.emission;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = this.transform.position;
        switch (level.value)
        {
            case 0:
                target.y = (-3.33f + 3.33f); // lol yes this is 0. I'll explain later
                break;
            case 1:
                target.y = (-4.9f + 3.33f);
                break;
            case 2:
                target.y = (-8.5f + 3.33f);
                break;
            case 3:
                target.y = (-12f + 3.33f);
                break;
            case 4:
                target.y = (-15.8f + 3.33f);
                break;
            default:
                break;
        }
        
        this.transform.position = Vector3.Lerp(this.transform.position, target, Time.deltaTime * 2);
        emission.enabled = Vector3.Distance(this.transform.position, target) > 0.1f;

        if (Vector3.Distance(this.transform.position, target) < 0.1f && !impact)
        {
            impact = true;
            ServiceLocator.GetService<IAudioService>().PlaySFX("building_impact");
        }
        else if(Vector3.Distance(this.transform.position, target) > 0.1f)
        {
            impact = false;
        }

    }
}
