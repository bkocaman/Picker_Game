using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : Singleton<GameManager>
{


    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject EndGameUI;
    [SerializeField] private GameObject PrepareUI;

    public bool gameover = false;
    public bool endgame = false;
    void Start()
    {
        GameOverUI.SetActive(false);
        EndGameUI.SetActive(false);
        PrepareUI.SetActive(true);
       
    }

  
    void Update()
    {

        if (gameover == true)
        {
            GameOverUI.SetActive(true);
           
        }

        else
        {
            GameOverUI.SetActive(false);
        }

        if (endgame == true)
        {
            EndGameUI.SetActive(true);
           
        }

        else
        {
            EndGameUI.SetActive(false);
        }

       
    }

    public void GameOverScene()
    {
        endgame = true;
    }
    public void TryAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        

    }

}

