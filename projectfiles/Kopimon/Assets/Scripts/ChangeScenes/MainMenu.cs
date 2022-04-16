using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Login()
    {
        SceneManager.LoadScene(2); //load login scene
    }

    public void SignUp()
    {
        SceneManager.LoadScene(3); //load sign up scene
    }

    public void Back()
    {
        SceneManager.LoadScene(1); //load sign up scene
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void SignUpFinish()
    {
        SceneManager.LoadScene(2); //load login scene
    }
}
