using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarterScript : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Scenes/Game");
    }
}
