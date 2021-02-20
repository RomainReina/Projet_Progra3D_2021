using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPos : MonoBehaviour
{
    [SerializeField] private Transform transformPlayer;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Respawn"))
        {
            Debug.Log("PASSE SOUS LA CARTE");

            RaycastHit hit;

            Debug.DrawRay(transform.position, transform.up * 100, Color.red);

            if (Physics.Raycast(transform.position, transform.up, out hit, 100))
            {
                Debug.Log("Hit: " + hit);
                transform.position = new Vector3(transform.position.x, hit.transform.position.y + 2, transform.position.z);
            }
        }
    }

}
