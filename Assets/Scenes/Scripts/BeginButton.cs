using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginButton : MonoBehaviour
{
    public void StartGame()
    {
        GuiManager.Instance.StarPosttGame();
    }
}
