using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public float distanceToPlayer;
    public GameObject player;
    public List<GameObject> enemies = new List<GameObject>();
    private Vector2 spawnPos;
    public bool isInstantiated = false;
    private readonly float enemyFallBorder = -20.0f;
    
    
    void Start()
    {
        spawnPos = transform.position;
    }

    void Update()
    {
        if (math.abs(player.transform.position.x - spawnPos.x) <= distanceToPlayer && !isInstantiated)
        {
            Instantiate(enemies[Random.Range(0, enemies.Count)], transform);
            isInstantiated = true;
        }
        if (isInstantiated && transform.childCount >= 1)
        {
            if (transform.GetChild(0).position.y < enemyFallBorder)
            {
                Destroy(transform.GetChild(0).gameObject);
                isInstantiated = !isInstantiated;
            }
        }
    }
}
