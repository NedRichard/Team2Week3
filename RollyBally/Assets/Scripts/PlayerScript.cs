using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(horizontal, 0, vertical);

        moveDir.Normalize();

        transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);

        if(moveDir != Vector3.zero) {

            Quaternion toRot = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation= Quaternion.RotateTowards(transform.rotation, toRot, rotationSpeed * Time.deltaTime);

        }
    }

}
