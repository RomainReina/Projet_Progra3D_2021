using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlenderTriggers : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // si le player est dans les environs, je met fin a la partie
        if (other.gameObject.layer == 7) // Layer = Player
        {
            SceneManager.LoadScene("LostScene");
        }
    }
}
