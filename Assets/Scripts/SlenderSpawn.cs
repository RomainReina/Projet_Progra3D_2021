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

    [SerializeField]
    private GameObject
        terrain; // je prend mon gameobject plan pour reduir la taille de spawn( le terrain en lui meme est trop grand !)

    [SerializeField] private LayerMask layerMask;

    [SerializeField] private GameObject slenderGO;

    //[SerializeField]  nbObject 

    [SerializeField] private float timer = 15f;
    private float updatedTimer;

    private float Xmax;
    private float Xmin;
    private float Zmax;
    private float Zmin;
    private float X;
    private float Z;

    private Collider _terrainCollider;


    private void Awake()
    {
        updatedTimer = timer;
        _terrainCollider = terrain.GetComponent<Collider>();

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
        Debug.DrawRay(newPos, transform.up * 100, Color.red); // ok 
        //Debug.Break();
        
        // si il y a un slender, je le kill
        foreach (Transform child in slenderGO.transform)
        {
            Debug.Log("Destroy Child: " + child.gameObject);
            Destroy(child.gameObject);
        }

        // je fait spawn un slender
            if (Physics.Raycast(newPos, -transform.up, out hit, 100, layerMask, QueryTriggerInteraction.Ignore))
            {
                newPos = new Vector3(newPos.x, 7, newPos.z);
                Debug.Log("Swpan Slender");
                Instantiate(prefabSlender, newPos, Quaternion.identity, slenderGO.transform);
            }
            else
            {
                Debug.Log("Le rayCast marche pas feegdvdxr");
            }
    }
    

    private Vector3 RandomPos()
    {
        // prend les extremiter su plane en question 
        var bounds = _terrainCollider.bounds;
        Xmax = bounds.max.x;
        Xmin = bounds.min.x;

        Zmax = bounds.max.z;
        Zmin = bounds.min.z;
        
        // et randomise 2 valeurs
        X = UnityEngine.Random.Range(Xmin, Xmax);
        Z = UnityEngine.Random.Range(Zmin, Zmax);

        return new Vector3(X, 30, Z);
    }
}
    



