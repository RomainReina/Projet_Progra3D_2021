using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointCounter : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private TextMeshProUGUI TMPCounter;
    
    [SerializeField] private float LimitPoint=5;
    
    [SerializeField] private string endingScene;

    
    // Update is called once per frame
    void Update()
    {
        var Point = parent.transform.childCount;
        
        TMPCounter.text = "Objets touvés: " + Point;
        TMPCounter.color = Color.white;
        
         // si je trouve 5 objets en enfant de 'parent', jai fini et je vais sur la page de fin
         if (Point == LimitPoint)
        {
            SceneManager.LoadScene(endingScene); // a faire
        }
    }
}
