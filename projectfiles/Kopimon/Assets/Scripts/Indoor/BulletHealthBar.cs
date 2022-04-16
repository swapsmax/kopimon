using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class BulletHealthBar : MonoBehaviour
{
    public Image FillImage;

    [PunRPC] public void ReduceHealth(float amount)
    {
        ModifyHealth(amount);
    }

    private void ModifyHealth(float amount)
    {
        PhotonView photonView = (PhotonView)this.GetComponent<PhotonView>();
        if(photonView.IsMine)
        {
            Debug.Log(amount);
            FillImage.fillAmount -= amount;
            Debug.Log("loss");
            if(FillImage.fillAmount <= 0)
            {
                LossPanel();
            }        
        }
        else
        {
            Debug.Log("reduce health others");
            FillImage.fillAmount -= amount;
            Debug.Log("win");
            if(FillImage.fillAmount <= 0)
            {
                WinPanel();
            }
        }
    }

    private void LossPanel()
    {
        GameObject ResultPanel = GameObject.Find("ResultPanel");
        GameObject losePanel =  ResultPanel.transform.Find("LosePanel").gameObject;   
        Debug.Log("Die");
        losePanel.SetActive(true);
    }

    private void WinPanel()
    {
        GameObject ResultPanel = GameObject.Find("ResultPanel");
        GameObject winPanel =  ResultPanel.transform.Find("WinPanel").gameObject;   
        Debug.Log("win");
        winPanel.SetActive(true);
    }

}
