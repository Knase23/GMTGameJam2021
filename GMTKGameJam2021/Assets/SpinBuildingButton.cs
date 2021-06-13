using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;

public class SpinBuildingButton : GameButton
{
    public int direction;
    public int rotationAngle;
    public GameObject topLevel;

    public override void Pressed()
    {
        base.Pressed();
        topLevel.transform.LeanRotateAround(new Vector3(0, 1, 0), rotationAngle * direction, 0.5f);
        ServiceLocator.GetService<IAudioService>().PlaySFX("building_rotate");
    }

}
