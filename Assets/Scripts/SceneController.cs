using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private UnityEvent onStartEvent = default;
    [SerializeField] private string nextScene;
    

    public void SceneLoader() {
        
        SceneManager.LoadScene(nextScene);
    }

    public void OnQuit() {
        Application.Quit();
    }
}

