using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject bird;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject shopButton;
    private Vector2 scale;
    private bool gameIsClicked = false;
    private bool shopIsClicked = false;

    private void Start()
    {
        shopButton.SetActive(true);
        playButton.SetActive(true);
    }

    private void Update()
    {
        if (gameIsClicked)
        {
            hideButtons();
            Invoke("growBird", 1f);
            Invoke("loadGame", 2f);
        }
        else if (shopIsClicked)
        {
            hideButtons();
            Invoke("growBird", 1f);
            Invoke("loadShop", 2f);
        }
    }
    public void playGame()
    {
        gameIsClicked = true;
    }
    public void playShop()
    {
        shopIsClicked = true;
    }

    private void growBird()
    {
        
        for (int i = 0; i < 5; i++)
        {
            scale = bird.transform.localScale;
            scale.x += 1f;
            scale.y += 1f;
            bird.transform.localScale = scale;
        }
    }

    private void loadGame()
    {
        SceneManager.LoadScene(0);
    }

    private void loadShop()
    {
        SceneManager.LoadScene(2);
    }

    private void hideButtons()
    {
        shopButton.SetActive(false);
        playButton.SetActive(false);
    }

}
