using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnScript : MonoBehaviour
{

    static List<GameObject> collectibles = new List<GameObject>();
    static List<GameObject> spawnedItems = new List<GameObject>();
    [SerializeField] GameObject goldenOne;
    [SerializeField] GameObject Eater;
    [SerializeField] NavMeshAgent spawnMesh;

    public static int spawnAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        collectibles.Add(goldenOne);
        Invoke("SpawnEater", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnAmount < 1) {
            SpawnCollectible();
        }
    }

    void SpawnCollectible() {

        Vector3 spawnLocation = new Vector3(transform.position.x + UnityEngine.Random.Range(-10, 10), 
        transform.position.y, transform.position.z + UnityEngine.Random.Range(-10, 10));

        spawnedItems.Add(Instantiate(collectibles[0], spawnLocation, Quaternion.identity));
        //GetComponent<NavMeshAgent>().Warp(spawnLocation);
        spawnMesh.Warp(spawnLocation);
        spawnAmount++;

    }

    void SpawnEater() {
        Vector3 EaterSpawn = new Vector3(8, 1, -8);
        Instantiate(Eater, EaterSpawn, Quaternion.identity);
    }

    void ItemSpawn() {
        
    }

    public static void DeleteItem() {
        //SpawnScript.Destroy(spawnedItems[0]);
        Destroy(spawnedItems[0]);
        spawnedItems.Remove(spawnedItems[0]);
        spawnAmount--;
        Debug.Log(spawnedItems.Count);
    }

}
