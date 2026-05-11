using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("스폰 설정")]
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnRadius = 10f;

    [Header("지면 설정")]
    public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
        
    }

    void SpawnEnemy()
    {
        Vector2 randCircle = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 rayOrigin = new Vector3(randCircle.x, 20f, randCircle.y);

        Collider groundCollider = ground.GetComponent<Collider>();
        if (groundCollider.Raycast(new Ray(rayOrigin, Vector3.down), out RaycastHit hit, 40f))
        {
            Vector3 spawnPos = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
