﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PondSpawnPointFood : MonoBehaviour {

    public GameObject[] foods;
    public int minWaitSpawn, maxWaitSpawn, minWaitDestroy, maxWaitDestroy, initialWaitRange;
    public Slider progressBar;
    public GameObject player;
    public float minSpawnRange;

    private float progressPoints;
    private int WaitCyclesSpawn, WaitCyclesDestroy, initialWait;
    private GameObject SpawnedFood;
    private int cycleCounter;
    private Vector2 trackPlayer;
    private float hypotenuse;

    enum Mstates
    {
        INITIAL,
        NOFOOD,
        FOODSPAWNED,
        FINAL
    };

    private Mstates state;

    // Use this for initialization
    void Start ()
    {
        state = Mstates.INITIAL;
        cycleCounter = 0;
        initialWait = Random.Range(1, initialWaitRange);
        WaitCyclesSpawn = Random.Range(minWaitSpawn, maxWaitSpawn + 1);
        WaitCyclesDestroy = Random.Range(minWaitDestroy, maxWaitDestroy + 1);
        progressPoints = progressBar.value;
    }

    private void FixedUpdate()
    {
        progressPoints = progressBar.value;
        switch (state)
        {
            case Mstates.INITIAL:
                if (cycleCounter < initialWait)
                {
                    cycleCounter++;
                }
                else
                {
                    SpawnedFood = Instantiate(foods[Random.Range(0, foods.Length)], transform.position, transform.rotation) as GameObject;
                    state = Mstates.FOODSPAWNED;
                    cycleCounter = 0;
                }
                if (progressPoints >= 1f)
                {
                    state = Mstates.FINAL;
                }
                break;

            case Mstates.FOODSPAWNED:
                if (SpawnedFood.activeSelf == false)
                {
                    Destroy(SpawnedFood);
                    cycleCounter = 0;
                    state = Mstates.NOFOOD;
                }
                else if (cycleCounter < WaitCyclesDestroy)
                {
                    cycleCounter++;
                }
                else
                {
                    Destroy(SpawnedFood);
                    cycleCounter = 0;
                    state = Mstates.NOFOOD;
                }
                if (progressPoints >= 1f)
                {
                    state = Mstates.FINAL;
                }
                break;

            case Mstates.NOFOOD:
                trackPlayer = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
                hypotenuse = Mathf.Sqrt((trackPlayer.x * trackPlayer.x) + (trackPlayer.y * trackPlayer.y));
                if (cycleCounter < WaitCyclesSpawn && hypotenuse >= minSpawnRange)
                {
                    cycleCounter++;
                }
                else if (cycleCounter >= minWaitSpawn)
                {
                    SpawnedFood = Instantiate(foods[Random.Range(0, foods.Length)], transform.position, transform.rotation) as GameObject;
                    state = Mstates.FOODSPAWNED;
                    cycleCounter = 0;
                }
                if (progressPoints >= 1f)
                {
                    state = Mstates.FINAL;
                }
                break;

            case Mstates.FINAL:
                if (!SpawnedFood.Equals(null))
                {
                    Destroy(SpawnedFood);
                }
                else
                {
                    ;
                }
                break;

            default:
                break;
        }

















        //    if (SpawnedFood.Equals(null))
        //    {
        //        if (cycleCounter < WaitCyclesSpawn)
        //        {
        //            cycleCounter++;
        //        }
        //        else
        //        {
        //            SpawnedFood = Instantiate(foods[Random.Range(0, foods.Length)], transform.position, transform.rotation) as GameObject;
        //            cycleCounter = 0;
        //        }
        //    }
        //    else if (SpawnedFood.activeSelf == false)
        //    {
        //        Destroy(SpawnedFood);
        //        cycleCounter = 0;
        //    }
        //    else
        //    {
        //        if (cycleCounter < WaitCyclesDestroy)
        //        {
        //            cycleCounter++;
        //        }
        //        else
        //        {
        //            Destroy(SpawnedFood);
        //            cycleCounter = 0;
        //        }
        //    }
        //}
    }
}


