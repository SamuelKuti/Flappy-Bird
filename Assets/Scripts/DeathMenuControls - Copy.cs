using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuControls : MonoBehaviour
{
    [SerializeField] private GameObject deathMenu;
    public void loadGame()
    {
        deathMenu.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
