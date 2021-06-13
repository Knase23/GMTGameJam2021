using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GapAndBridge : MonoBehaviour
{
    public SpriteRenderer bridgePiece;
    public Sprite gapWithoutBridge;
    public Sprite gapWithBridge;

    public Boolean bridgeBuilt;
    public BoxCollider barrier;

    private bool lastKnownState;

    void Start()
    {
        bridgePiece.sprite = gapWithoutBridge;
        bridgeBuilt.flag = false;
    }

    void Update()
    {
        if (lastKnownState != bridgeBuilt.flag)
        {
            lastKnownState = bridgeBuilt.flag;
            UpdateBridge();
        }
    }

    private void UpdateBridge()
    {
        barrier.gameObject.SetActive(!bridgeBuilt.flag);
        bridgePiece.sprite = bridgeBuilt.flag ? gapWithBridge : gapWithoutBridge;
    }
}
