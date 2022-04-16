using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EssentialObjects : MonoBehaviour
{
    private void Awake()
    { 
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == "EspRegister" ) {
            GameObject.Destroy(GameObject.Find("EssentialObjects(Clone)"));
        }

        if (scene.name == "EspIndoor" ) {
            GameObject.Destroy(GameObject.Find("EssentialObjects"));
        }

 }
}
