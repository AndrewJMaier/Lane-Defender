using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private AudioClip _lifeLostAudio;

    // Start is called before the first frame update
    void Start()
    {
        _lives = 3;
    }

    //Reduces player lives
    public void LifeLost()
    {
        _lives--;
        GetComponent<AudioSource>().loop = false;
        GetComponent<AudioSource>().clip = _lifeLostAudio;
        GetComponent<AudioSource>().Play();
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

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
