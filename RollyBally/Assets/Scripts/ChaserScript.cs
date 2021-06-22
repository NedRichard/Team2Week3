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
        //SimpleChase();
        ChasePlayer();
    }

    void SimpleChase() {
        agent.destination = target.transform.position;
    }

    void ChasePlayer() {
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        agent.SetDestination(target.transform.position);
    }



}
