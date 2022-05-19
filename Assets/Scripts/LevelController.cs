using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    private float _timer;

    [SerializeField] private GameObject LevelCompletePanel;
    [SerializeField] private GameObject DefeatePanel;

    [SerializeField] private GameObject Player;

    void Awake()
    {
        _timer = 30.0f; 
        UIController._isPaused = false;
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        _timerText.text = Mathf.Ceil(_timer).ToString();

        if(_timer <= 0)
        {
            UIController._isPaused = true;
            LevelCompletePanel.SetActive(true);
            _timer = 0;
        }

        if(Player == null)
        {
            DefeatePanel.SetActive(true);
        }
    }
}
