using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;

    public Generator terrainGenerator;

    public GameObject playerPrefab;
    public GameObject terrainPrefab;
    public GameObject powerUpPrefab;

    public Material groundMaterial;

    public float pickupChance = 5;

    public int startingRing = 3;
    public int startingRingCount = 3;
    private int currentRing;

    private PlayerControler playerControler = null;

    private void Awake()
    {
        instance = this;
        terrainGenerator.GenerateSpawn();
        playerControler = GeneratePlayer();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RespawnPlayer());

        DateTime startGenerateTime = DateTime.Now;
        //Generate default rings

        for (int i = startingRing; i <= startingRing + startingRingCount; i++)
        {
            terrainGenerator.GenerateRing(i);
        }
        Debug.Log("Generate time: " + (DateTime.Now - startGenerateTime).ToString());

    }

    IEnumerator RespawnPlayer()
    {
        yield return null;
        playerControler.Respawn();
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
