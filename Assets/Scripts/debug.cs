using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debug: MonoBehaviour
{
    [SerializeField] private GameObject terrain;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(terrain.GetComponent<TerrainCollider>().bounds.max.x);
        Debug.Log(terrain.GetComponent<TerrainCollider>().bounds.min.x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}