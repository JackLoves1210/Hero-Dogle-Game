using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public GameObject pnlEndGame;
    public Button btnRestart;
    public Text txtPoint;
    public int gamePoint;

    void Start()
    {
        Time.timeScale = 1;
        pnlEndGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }
    public void EndGame()
    {
        Time.timeScale = 0;
        pnlEndGame.SetActive(true);
    }
}
