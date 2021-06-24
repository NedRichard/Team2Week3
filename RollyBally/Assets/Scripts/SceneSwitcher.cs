using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static void MoveToGameView() {
        SceneManager.LoadScene("GameView");
    }

    public static void ExitGame() {
        Application.Quit();
    }
}
