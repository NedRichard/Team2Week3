using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleContact : MonoBehaviour
{

    void OnTriggerEnter(Collider col) {

        if(col.CompareTag("Player")) {

            FindObjectOfType<GameManager>().IncreasePlayerScore();
            SpawnScript.DeleteItem();

        } else if(col.CompareTag("Eater")) {

            FindObjectOfType<GameManager>().IncreaseEaterScore();
            SpawnScript.DeleteItem();
            
        }

    }
}
