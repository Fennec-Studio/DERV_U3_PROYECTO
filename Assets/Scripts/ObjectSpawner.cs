using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn; // El prefab del objeto a spawnear
    [SerializeField] int numberOfObjects = 10; // Cantidad de objetos a spawnear
    [SerializeField] AudioSource coinSound;

    private Vector3 spawnCenter;
    private Vector3 planeSize;

    void Start()
    {
        MeshRenderer planeRenderer = GetComponent<MeshRenderer>();
        planeSize = planeRenderer.bounds.size;
        spawnCenter = transform.position;
        SpawnObjects();
        coinSound.Stop();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = new Vector3(
                spawnCenter.x + Random.Range(-planeSize.x / 2, planeSize.x / 2),
                spawnCenter.y + 0.5f,
                spawnCenter.z + Random.Range(-planeSize.z / 2, planeSize.z / 2)
            );

            GameObject spawnedObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
            spawnedObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            BoxCollider boxCollider = spawnedObject.AddComponent<BoxCollider>();
            boxCollider.size = new Vector3(0.7f, 0.7f, 0.7f);
            
            spawnedObject.AddComponent<RotateCoin>();
            spawnedObject.AddComponent<CoinBonusCollect>();
            spawnedObject.GetComponent<CoinBonusCollect>().prueba = coinSound;
        }
    }
}
