using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void Retry() {
        GameManager.instance.Retry();
    }

    public void MainMenu() {
        GameManager.instance.MainMenu();
    }
}
