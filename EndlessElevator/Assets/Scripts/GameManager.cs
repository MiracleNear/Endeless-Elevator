using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject buttonEnd;

    public bool _endGame;
    private UiManager uiManager;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        uiManager = GetComponent<UiManager>();
        _endGame = false;
    }


    public void UpdateUi()
    {
        uiManager.UpdateUiScore();
    }



    public void IncreaseScore()
    {
        uiManager.IncreaseScore();
    }
    


    public void PressButtonEnd()
    {
        _endGame = true;
        SceneManager.LoadScene("Menu");

    }


    public void EndGame()
    {
        buttonEnd.SetActive(true);
        StartCoroutine(uiManager.ViewEndGame());
    }
}
