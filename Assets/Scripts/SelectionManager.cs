using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private GameObject ObjectFind;
    

    private Transform _selection;

    // le but ici est de voir si le cube est selectionné, si oui il aparait en jaune, sinon bleu
    void Update()
    {
        if (_selection != null)
        {
            // cette section permet de remettre la couleur d'origine au cube ici bleu
            var selectionRenderer = _selection.GetComponent<Renderer>(); 
            selectionRenderer.material = defaultMaterial;  // on prend le renderer du cube, ici bleu
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition); // le raycast est en fonction de la position de la camera
        
        RaycastHit hit;
        Debug.DrawRay(transform.position,transform.forward*3f,Color.red);
        
        if (Physics.Raycast(ray, out hit,3f))
        {
            // si je touche quelque chose je regarde si c'est un objet selectionnable
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {   
                // si oui son material devient highlightMaterial ( jaune) 
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    if (Input.GetButton("Fire1"))
                    {
                        // si j'appuis sur Fire1, je detruit le cube et j'en crée un autre dans un GameObject different pour compter les points
                        Debug.Log("Destroy " + hit.transform.gameObject);
                        var Object = hit.transform.gameObject;
                        // il faut detruire l'objet et mettre un point 
                        Instantiate(Object,ObjectFind.transform);
                        
                        Destroy(Object);
                    }
                }

                _selection = selection;
            }
        }
    }
}
