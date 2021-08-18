using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly object collided");
                break;
            case "Finish":
                Debug.Log("Collided with finish");
                break;
            case "Fuel":
                Debug.Log("Collided with fuel");
                break;
            default:
                Debug.Log("UFO");
                ReloadScene();
                break;
        }
    }

    private void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}