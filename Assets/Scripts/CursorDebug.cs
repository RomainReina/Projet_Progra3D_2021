using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorDebug : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        // surement avec la selectio d'objet avec la souris, on ne peux plus clicker sur les bouton quand on change
        // de scene, j'ai donc crée ce scripts pour corriger le probleme
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
