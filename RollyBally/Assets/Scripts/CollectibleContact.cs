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

            FindObjectOfType<GameManager>().IncreasePlayerScore();
            SpawnScript.DeleteItem();

        } else if(col.CompareTag("Eater")) {

            FindObjectOfType<GameManager>().IncreaseEaterScore();
            SpawnScript.DeleteItem();
            
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

        if(randomPick == 4) {

            Debug.Log("Playing first sound");
            soundOne.Play();

        }else if(randomPick == 5) {

            Debug.Log("Playing second sound");
            soundTwo.Play();

        }

    }
}
