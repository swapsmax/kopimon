using Photon.Pun;
using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  
public class GoBack: MonoBehaviour {  
    public void Goback() {
        //StartCoroutine(DisconnectAndLoad());
        SceneManager.LoadScene("Gameplay");  
    }
    //IEnumerator DisconnectAndLoad()
    //{
        //PhotonNetwork.Disconnect();
        //while (PhotonNetwork.IsConnected)
            //yield return null;
       // SceneManager.LoadScene("Gameplay");
    //}
}
