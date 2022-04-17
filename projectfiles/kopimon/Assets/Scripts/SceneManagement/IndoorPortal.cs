using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IndoorPortal : MonoBehaviour, IPlayerTriggerable
{

    PlayerController player;
    public void OnPlayerTriggered(PlayerController player)
    {
        player.Character.Animator.IsMoving = false;
        this.player = player;
        SceneManager.LoadScene("EspRegister");
    }

    public bool TriggerRepeatedly => false;
}

