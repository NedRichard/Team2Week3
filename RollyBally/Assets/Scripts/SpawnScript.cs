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


    [SerializeField] GameObject Strawberry;
    [SerializeField] GameObject Banana;
    [SerializeField] GameObject Apple;
    [SerializeField] GameObject Melon;


    [SerializeField] GameObject Chaser;
    [SerializeField] GameObject Eater;
    [SerializeField] NavMeshAgent spawnMesh;

    public static int spawnAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //All collectibles
        collectibles.Add(Strawberry);
        collectibles.Add(Banana);
        collectibles.Add(Apple);
        collectibles.Add(Melon);

        //Fixed spawn locations
        spawnLocations.Add(new Vector3(0, 0.5f, 0));
        spawnLocations.Add(new Vector3(-12.5f, 0.5f, 12.5f));
        spawnLocations.Add(new Vector3(12.5f, 0.5f, 12.5f));
        spawnLocations.Add(new Vector3(-12.5f, 0.5f, -12.5f));
        spawnLocations.Add(new Vector3(12.5f, 0.5f, -12.5f));

        Invoke("SpawnChaser", 0.5f);

        //Adding Eater
        Invoke("SpawnEater", 1.0f);

        ItemSpawn();

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

    void SpawnChaser() {
        Vector3 ChaserSpawn = new Vector3(0, 1, -12.5f);
        Instantiate(Chaser, ChaserSpawn, Quaternion.identity);
    }

    void SpawnEater() {
        Vector3 EaterSpawn = new Vector3(0, 1, -8.5f);
        Instantiate(Eater, EaterSpawn, Quaternion.identity);

    }

    void ItemSpawn() {

        //Pick a spawn
        int sizeOfList = spawnLocations.Count;
        int index;

        //Pick a different spawn point than last one
        do {
            
            index = Random.Range(0, sizeOfList);

            if(index == recentSpawn) {
                //Debug.Log("Picking a new spawn");
            }
            
        } while(index == recentSpawn);

        recentSpawn = index;
        //Debug.Log("Recent spawn location: " + recentSpawn);

        //Pick a collectible
        int collectibleList = collectibles.Count;
        int colIndex = Random.Range(0, collectibleList);

        Vector3 spawnLocation = spawnLocations[index];

        //Used Quaternion.identity
        //Changed to collectibles[colIndex].transform.rotation
        spawnAmount++;
        spawnedItems.Add(Instantiate(collectibles[colIndex], spawnLocation, collectibles[colIndex].transform.rotation));

        spawnMesh.Warp(spawnLocation);
        

    }

    public static void DeleteItem() {
        
        Destroy(spawnedItems[0]);
        spawnedItems.RemoveAt(0);
        spawnAmount--;
        //Debug.Log(spawnedItems.Count);
    }

}
