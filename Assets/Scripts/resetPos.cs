using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPos : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject player;

    private Vector3 transformPlayer;
    
    // Start is called before the first frame update
    
    private void Update()
    {
        transformPlayer = player.transform.position;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Respawn"))
        {
            Debug.Log("PASSE SOUS LA CARTE");

            RaycastHit hit;
            
            if (Physics.Raycast(transformPlayer + transform.up*100,-transform.up,out hit,100,layerMask,QueryTriggerInteraction.Ignore))
            {
                Debug.DrawRay(transformPlayer * 100,-transform.up *100, Color.red);
                Debug.Log("Hit: " + hit.collider.name);
                Debug.Log("TP a la Pos: " + hit.collider.transform.position); // y=  5 pourtout le terrain :( je met une valeur fixe qui va bien
                transform.position = new Vector3(transformPlayer.x, hit.transform.position.y + 10, transformPlayer.z);
                Debug.Log("TP");
            }
        }
    }

}
