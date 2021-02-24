using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Projet
{
    [CreateAssetMenu(
    fileName = "NewDialogue",
    menuName = "Dialogue")]

    public class DialogueClass : ScriptableObject
    {

        [SerializeField] private string text;

        // Getter et Setter
        public string Dialogue
        {
            get => text;
            set => text = value;
        }
        
        
    }
}



