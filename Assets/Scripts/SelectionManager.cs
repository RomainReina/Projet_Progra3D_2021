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

    // Update is called once per frame
    void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit;
        Debug.DrawRay(transform.position,transform.forward*3f,Color.red);
        
        if (Physics.Raycast(ray, out hit,3f))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    if (Input.GetButton("Fire1"))
                    {
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
