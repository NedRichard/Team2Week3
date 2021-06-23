using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Eater : MonoBehaviour
{

    GameObject target;

    [SerializeField] NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target=GameObject.FindGameObjectWithTag("Collectible");
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target==null) {
            target=GameObject.FindGameObjectWithTag("Collectible");
        } else {
            ChaseCollectible();
        }
        
    }

    void ChaseCollectible() {
        agent.SetDestination(target.transform.position);
    }

    void OnTriggerEnter(Collider col) {
        if(col.CompareTag("Player")) {
            Debug.Log("Game Over!");
        }
    }

}
