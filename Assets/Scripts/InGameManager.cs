using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public Generator terrainGenerator;

    public GameObject playerPrefab;

    public int startingRing = 3;
    public int startingRingCount = 3;
    private int currentRing;

    private PlayerControler playerControler = null;

    private void Awake()
    {
        terrainGenerator.GenerateSpawn();
        playerControler = GeneratePlayer();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RespawnPlayer());

        //Generate default rings

        for(int i = startingRing; i <= startingRing + startingRingCount; i++)
        {
            terrainGenerator.GenerateRing(i);
        }
    }

    IEnumerator RespawnPlayer()
    {
        yield return null;
        playerControler.Respawn();
        
        //*
        DateTime start = DateTime.Now;
        yield return new WaitForSeconds(60f);
        Debug.Log("Run time: " + (DateTime.Now - start).ToString());
        playerControler.Respawn();
        //*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerControler GeneratePlayer()
    {
        GameObject player = GameObject.Instantiate(playerPrefab);
        PlayerControler playerControler = player.GetComponent<PlayerControler>();
        return playerControler;
    }
}
