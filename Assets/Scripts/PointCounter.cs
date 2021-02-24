using System;
using System.Collections;
using System.Collections.Generic;
using Projet;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointCounter : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private TextMeshProUGUI TMPCounter;
    
    [SerializeField] private float LimitPoint=5;
    
    [SerializeField] private string endingScene;
    
    [SerializeField] private DialogueClass wonDialogue;
    [SerializeField] private DialogueClass lostDialogue;
    [SerializeField] private DialogueClass nextDialogue;

    private void Start()
    {
        // on set le prochain dialogue a 'lose' par defaut
        nextDialogue.Dialogue = lostDialogue.Dialogue;
    }

    // Update is called once per frame
    void Update()
    {
        var Point = parent.transform.childCount;
        
        TMPCounter.text = "Objets touvés: " + Point;
        TMPCounter.color = Color.white;
        
        // si je trouve 5 objets en enfant de 'parent', jai fini et je vais sur la page de fin
         if (Point == LimitPoint)
         {
             // si on gagne, on change de 'lose' a 'win'
             nextDialogue.Dialogue = wonDialogue.Dialogue;
             SceneManager.LoadScene(endingScene); 
            
        }
        
    }
}
