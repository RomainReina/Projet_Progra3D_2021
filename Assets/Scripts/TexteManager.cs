using System.Collections;
using System.Collections.Generic;
using Projet;
using TMPro;
using UnityEngine;

public class TexteManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private DialogueClass Text;
    [SerializeField] private TextMeshProUGUI dialogueTextComponent;
    
    
    void Update()
    {
        // pour changer le message d'un TMP
        dialogueTextComponent.text = Text.Dialogue;
    }
}
