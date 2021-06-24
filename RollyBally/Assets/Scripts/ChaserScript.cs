using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaserScript : MonoBehaviour
{

    public float moveSpeed = 1f;

    public GameObject target;

    [SerializeField] NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        if(target==null) {
            target=GameObject.FindGameObjectWithTag("Player");
        }

    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer() {
        target=GameObject.FindGameObjectWithTag("Player");
        agent.SetDestination(target.transform.position);
        
    }

    void OnTriggerEnter(Collider col) {

        if(col.CompareTag("Player")){

            //Debug.Log("Game Over!");
            FindObjectOfType<GameManager>().EndGame();
                   
        }
        
    }

}
