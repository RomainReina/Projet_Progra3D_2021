using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
    [SerializeField] private GameObject terrain;

    //[SerializeField]  nbObject 

    [SerializeField] private float timer = 1f;
    private float updatedTimer;

    private float Xmax;
    private float Xmin;
    private float Zmax;
    private float Zmin;
    private float X;
    private float Z;

    private TerrainCollider _terrainCollider;
    

    private void Awake()
    {
        updatedTimer = timer;
        _terrainCollider = terrain.GetComponent<TerrainCollider>();

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
        // choisi une pos sur le board
        Vector3 newPos = RandomPos();
        Debug.Log("new Pos SlenderPawn:" + newPos);
        
        //on regarde si le slender peux spawn à cette pos, puis on le fait  spawn
        RaycastHit hit;

        if (Physics.Raycast(newPos, transform.up, out hit, 1000))
        {
            newPos = new Vector3(newPos.x, hit.transform.position.y + 2, newPos.z);
            Debug.Log("Swpan Slender");
            Instantiate(prefabSlender,newPos,Quaternion.identity);
        }
        

    }

    private Vector3 RandomPos()
    {
        Xmax = _terrainCollider.bounds.max.x;
        Xmin = _terrainCollider.bounds.min.x;
        
        Zmax = _terrainCollider.bounds.max.z;
        Zmin = _terrainCollider.bounds.min.z;

        X = UnityEngine.Random.Range(Xmin,Xmax);
        Z = UnityEngine.Random.Range(Zmin,Zmax);

        return new Vector3(X, -100, Z);
    }


}



