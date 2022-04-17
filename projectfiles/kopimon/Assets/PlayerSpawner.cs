using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using Random=UnityEngine.Random;

public class PlayerSpawner : MonoBehaviour
{
    //public GameObject playerPrefabs;
    public GameObject[] playerPrefabs;
    public Transform[] spawnPoints;
    //public Transform spawnPoints;
    //[SerializeField] GameObject minimapWindow;

    // Start is called before the first frame update
    void Start()
    {
        //minimapWindow.SetActive(false); 
        int randomNumber = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomNumber];
        GameObject playerToSpawn;
        try {
            playerToSpawn = playerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        }       
        catch (NullReferenceException ex) {
            playerToSpawn = playerPrefabs[0];
        }
        //GameObject playerToSpawn = playerPrefabs;
        PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, Quaternion.identity);
    }


}
