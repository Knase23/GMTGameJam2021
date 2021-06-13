using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseBuildingButton : GameButton
{
    public Integer currentFloor;
    public int direction;

    protected override void Start()
    {
        base.Start();
    }

    public override void Pressed()
    {
        base.Pressed();
        if (currentFloor.value + direction < 0) return;
        if (currentFloor.value + direction > 4) return;

        Debug.Log("up down pressed");
        if (direction == 1)
        {
            currentFloor.value++;
        }
        else
        {
            currentFloor.value--;
        }
    }
}
