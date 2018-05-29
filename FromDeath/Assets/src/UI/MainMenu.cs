using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MainMenu : MonoBehaviour {

    [SerializeField]
    private Button _playButton;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private GameObject _gameController;
    [SerializeField]
    private Text _bestScore; 

    private void Awake()
    {
        _bestScore.text = "/<color=#202128>BEST</color> " + PlayerPrefs.GetInt("Score", 0).ToString() + "<color=#202128>M</color>"; 
    }

    public void SetActive(bool _flag)
    {
        gameObject.SetActive(_flag);
        _gameController.SetActive(!_flag); 
    }

    public void Close()
    {
        _animator.SetTrigger("Close");
    }

    public void CloseEvent()
    {
        SetActive(false); 
    }
}
