using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUI : MonoBehaviour
{
    public void HandleUpdate(Action onBack)
    {
        if (Input.GetKeyDown(KeyCode.X))
            onBack?.Invoke();
    }
}
