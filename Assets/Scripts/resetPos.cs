using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPos : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Respawn"))
        {
            Debug.Log("PASSE SOUS LA CARTE");

            Vector3 up = transform.TransformDirection(Vector3.up);

            RaycastHit hit;

            Debug.DrawRay(transform.position, up * 100, Color.red);

            if (Physics.Raycast(transform.position, up, out hit, 100))
            {
                Debug.Log("VOUS AVEZ ETE TP");
                transform.position = new Vector3(transform.position.x, hit.transform.position.y + 2, transform.position.z);
            }
        }
    }

}
