using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleContact : MonoBehaviour
{

    void OnTriggerEnter(Collider col) {

        if(col.CompareTag("Player") || col.CompareTag("Eater")){

            Debug.Log("Item picked up!");
            SpawnScript.DeleteItem();
            
        }

    }
}
