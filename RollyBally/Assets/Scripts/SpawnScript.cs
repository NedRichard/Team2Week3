using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnScript : MonoBehaviour
{

    static List<GameObject> collectibles = new List<GameObject>();
    static List<GameObject> spawnedItems = new List<GameObject>();

    int recentSpawn = 0;

    List<Vector3> spawnLocations = new List<Vector3>();


    [SerializeField] GameObject goldenOne;

    [SerializeField] GameObject Banana;
    [SerializeField] GameObject Eater;
    [SerializeField] NavMeshAgent spawnMesh;

    public static int spawnAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        collectibles.Add(goldenOne);

        spawnLocations.Add(new Vector3(0, 0.5f, 0));
        spawnLocations.Add(new Vector3(-12.5f, 0.5f, 12.5f));
        spawnLocations.Add(new Vector3(12.5f, 0.5f, 12.5f));
        spawnLocations.Add(new Vector3(-12.5f, 0.5f, -12.5f));
        spawnLocations.Add(new Vector3(12.5f, 0.5f, -12.5f));



        Invoke("SpawnEater", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnAmount < 1) {
            //SpawnCollectible();
            ItemSpawn();
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
        Vector3 EaterSpawn = new Vector3(0, 1, -8.5f);
        Instantiate(Eater, EaterSpawn, Quaternion.identity);
    }

    void ItemSpawn() {

        int sizeOfList = spawnLocations.Count;
        int index = Random.Range(0, sizeOfList);

        recentSpawn = index;
        //Debug.Log("Recent spawn location: " + recentSpawn);

        Vector3 spawnLocation = spawnLocations[index];

        spawnedItems.Add(Instantiate(collectibles[0], spawnLocation, Quaternion.identity));

        spawnMesh.Warp(spawnLocation);
        spawnAmount++;

    }

    public static void DeleteItem() {
        
        Destroy(spawnedItems[0]);
        spawnedItems.RemoveAt(0);
        spawnAmount--;
        //Debug.Log(spawnedItems.Count);
    }

}