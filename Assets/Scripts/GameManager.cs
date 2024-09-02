using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //int variables
    [SerializeField] private int _highScore;
    [SerializeField] private int _score;
    [SerializeField] private int _lives;
    //UI variables
    [SerializeField] private TMP_Text _highScoreText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _livesText;
    [SerializeField] private GameObject _loseScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        _lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LifeLost()
    {
        _lives--;
        if (_lives <= 0)
        {
            _loseScreen.SetActive(true);
        }
        else 
        {
            _livesText.text = ("Lives: " + _lives);//.ToString();
        }
    }

    public void ScoreKeeper()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
        }
    }
}
