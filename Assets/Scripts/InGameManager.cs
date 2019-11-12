using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;

    public Generator terrainGenerator;

    public float farClippingPlane = 200;

    public GameObject playerPrefab;
    public GameObject terrainPrefab;
    public GameObject powerUpPrefab;

    public Material groundMaterial;

    public float pickupChance = 5;

    public int startingRing = 3;
    public int startingRingCount = 3;
    private int currentRing;

    public int ringWidth = 5;

    public bool generateProceduraly = true;
    public int loadDistance = 5;

    private PlayerControler playerControler = null;

    public ChunkManager chunkManager;

    private void Awake()
    {
        instance = this;
        terrainGenerator.GenerateSpawn();
        playerControler = GeneratePlayer();
        chunkManager = new ChunkManager(ringWidth);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RespawnPlayer());

        DateTime startGenerateTime = DateTime.Now;
        //Generate default rings

        currentRing = startingRing + startingRingCount;
        for (int i = startingRing; i <= currentRing; i++)
        {
            terrainGenerator.GenerateRing(i, ringWidth, chunkManager);            
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
        if(generateProceduraly && (playerControler != null))
        {
            float largestAxes = Math.Abs(playerControler.transform.position.x);
            float z = Math.Abs(playerControler.transform.position.z);
            if (z > largestAxes) largestAxes = z;

            var distance = largestAxes / ringWidth;
            int ringDistance = (int)Math.Ceiling(distance);
            if(ringDistance + loadDistance >= currentRing)
            {
                currentRing++;
                DateTime startGenerateTime = DateTime.Now;
                terrainGenerator.GenerateRing(currentRing, ringWidth, chunkManager);
                Debug.Log("Finished generating ring(" + currentRing.ToString() + ") time: " + (DateTime.Now - startGenerateTime).ToString());
            }
        }
    }

    public PlayerControler GeneratePlayer()
    {
        GameObject player = GameObject.Instantiate(playerPrefab);
        PlayerControler playerControler = player.GetComponent<PlayerControler>();
        Camera playerCamera = player.GetComponentInChildren<Camera>();
        playerCamera.farClipPlane = farClippingPlane;
        return playerControler;
    }
}
