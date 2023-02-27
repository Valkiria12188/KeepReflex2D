using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningController : MonoBehaviour
{
    private GameObject gameContainer;

    [SerializeField] private float delayTime;
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private GameObject[] SpawnObjects;

    [SerializeField] private GameManager gameManager;

    int scoreing = 0;

    private void Awake()
    {
        gameContainer = GameObject.Find("GameContainer");
    }

    void Update()
    {
        scoreing = gameManager.score;
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnManager), delayTime, spawnTime);
    }
    private void SpawnManager()
    {
        int randomObj = Random.Range(0, SpawnObjects.Length);
        SpawnPoints(SpawnObjects[randomObj]);
    }

    private void SpawnPoints(GameObject box)
    {
        float randomIndex = Random.Range(-1.5f, 1.5f);
        Vector3 spawnIndex = new Vector3(randomIndex, spawnPoint.position.y, 0);
        Instantiate(box, spawnIndex, Quaternion.identity, gameContainer.transform);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnManager));
    }

    private void ReduceSpawnTime(float time)
    {
        spawnTime = time;
    }
}
