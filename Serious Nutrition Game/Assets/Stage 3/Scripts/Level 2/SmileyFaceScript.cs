﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileyFaceScript : MonoBehaviour {

    private faceStates state;
    public Sprite happyFace;
    public Sprite confusedFace;
    public Sprite cheerFace;
    public int wait;
    private int cycleCounter;
    private SpriteRenderer sr;

    enum faceStates
    {
        HAPPY,
        CONFUSED,
        CHEER
    };

    // Use this for initialization
    void Start()
    {
        state = faceStates.HAPPY;
        sr = this.GetComponent<SpriteRenderer>();
        cycleCounter = 0;
    }

    void Update()
    {
        switch (state)
        {
            case faceStates.HAPPY:
                if (sr.sprite != happyFace)
                {
                    sr.sprite = happyFace;
                }
                break;
            case faceStates.CONFUSED:
                if (sr.sprite != confusedFace)
                {
                    sr.sprite = confusedFace;
                }
                if (cycleCounter > 0)
                {
                    cycleCounter--;
                }
                else
                {
                    state = faceStates.HAPPY;
                }
                break;
            case faceStates.CHEER:
                if (sr.sprite != cheerFace)
                {
                    sr.sprite = cheerFace;
                }
                if (cycleCounter > 0)
                {
                    cycleCounter--;
                }
                else
                {
                    state = faceStates.HAPPY;
                }
                break;
            default:
                break;

        }
    }

    public void SetFaceState(int stateNum)
    {
        switch(stateNum)
        {
            case 0:
                this.state = faceStates.CONFUSED;
                break;
            case 1:
                this.state = faceStates.CHEER;
                break;
            default:
                break;
        }
        cycleCounter = wait;

    }
}
