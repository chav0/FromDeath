using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class LoseWindow : MonoBehaviour {

    [SerializeField]
    private Text _bestScore;
    [SerializeField]
    private Text _currentScore;
    [SerializeField]
    private Text _gemScore;
    [SerializeField]
    private Button _buttonTryAgain; 

    private int _currentScoreValue; 

    private void Awake()
    {
        _bestScore.text = "<color=#202128>BEST SCORE</color> " + PlayerPrefs.GetInt("Score", 0).ToString();
        _currentScore.text = "<color=#202128>CURRENT SCRORE</color> " + _currentScoreValue.ToString();
        _buttonTryAgain.onClick.AddListener(Reinit);
    }

    public void SetCurrentScore(int score)
    {
        _currentScoreValue = score;
    }

    private void Reinit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
