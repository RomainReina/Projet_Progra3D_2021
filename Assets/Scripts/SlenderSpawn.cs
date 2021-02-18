using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SlenderSpawn : MonoBehaviour
{

    /*
     * tout les 15 se seconde, slender change de position. //OK
     * il se deplace aleatoirement depuis son point de spawn.  // AUTRE SCRIPTS
     * il spawn aleatoirement, le radius de spawn baisse suivant le nombre d'objets possede par le joueur.
     * le spawn s'effectue grace a un raycast depuis le fond de la scene et cherche le mesh le plus proche( le terrain) et fait spawn slender
     */

    [SerializeField] private GameObject prefabSlender;
    //[SerializeField]  nbObject 

    [SerializeField] private float timer = 15f;
    private float updatedTimer;

    private void Awake()
    {
        updatedTimer = timer;
    }

    void Update()
    {
        if (updatedTimer < 0)
        {
            SlenderSpawnRaycast();
            updatedTimer = timer;
        }
        else
        {
            updatedTimer -= Time.deltaTime;
        }
    }
    

    private void SlenderSpawnRaycast()
    {
        RaycastHit raycastHit;
        Physics.Raycast(Vector3.Normalize(), transform.TransformDirection(Vector3.up));
        
    }
}

