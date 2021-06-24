using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleContact : MonoBehaviour
{

    public AudioSource soundOne;

    public AudioSource soundTwo;

    void OnTriggerEnter(Collider col) {

        PlaySound();

        if(col.CompareTag("Player")) {

            SpawnScript.DeleteItem();
            FindObjectOfType<GameManager>().IncreasePlayerScore();

        } else if(col.CompareTag("Eater")) {

            SpawnScript.DeleteItem();
            FindObjectOfType<GameManager>().IncreaseEaterScore();
            
        }

    }

    void PlaySound() {

        int randomPick = Random.Range(0, 2);

        switch(randomPick) {

            case 0:

                //Debug.Log("Playing first sound");
                soundOne.Play();
                break;

            case 1:

                //Debug.Log("Playing second sound");
                soundTwo.Play();
                break;

            default:
                break;

        }

    }
}
