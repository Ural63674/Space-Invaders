using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Text _numberScoreText;
    public static int numberScore;
    public static bool _isPaused = false;

    [SerializeField] private Text _totalVictoryScoreText;
    [SerializeField] private Text _totalDefeateScoreText;

    private void Awake()
    {
        numberScore = 0;
        _numberScoreText.text = numberScore.ToString();
    }
   
    private void Update()
    {
        _numberScoreText.text = "Score: " + numberScore;
        _totalVictoryScoreText.text = numberScore.ToString();
        _totalDefeateScoreText.text = numberScore.ToString();

        if (_isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void OnContinueClick()
    {
        menuPanel.SetActive(false);
        _isPaused = false;
    }
    public void OnRestartClick()
    {
        menuPanel.SetActive(false);        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _isPaused = false;
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

    public void OnMenuClick()
    {
        menuPanel.SetActive(true);
        _isPaused = true;
    }

    public void OnStartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }   

    public void OnNextLevelClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene(0);
    }
}
