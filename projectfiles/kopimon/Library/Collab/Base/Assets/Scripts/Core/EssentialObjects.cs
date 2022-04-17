using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EssentialObjects : MonoBehaviour
{
     //PhotonView view;

    private void Awake()
    {
        //view = GetComponent<PhotonView>();
        //if (view.IsMine)
        //{
            DontDestroyOnLoad(gameObject);
        //}
    }
}
