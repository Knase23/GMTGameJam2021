using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Collectible
{
    public int value;

    public override void Collect()
    {
        // add exp based on value;
        Destroy(this.transform.parent.gameObject);
    }
}
