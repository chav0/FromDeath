using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour {

    [SerializeField]
    private Transform _camera;
    [SerializeField]
    private LoseWindow _loseWindow;
    [SerializeField]
    private GameObject _gameController;
    [SerializeField]
    private GameObject _gameGenerator;

    public void Save()
    {
        if(PlayerPrefs.GetInt("Score", 0) < (int)Mathf.Round(_camera.position.y))
        {
            PlayerPrefs.SetInt("Score", (int)Mathf.Round(_camera.position.y)); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();

        if (pc != null)
        {
            Save(); 
            _loseWindow.SetCurrentScore((int)Mathf.Round(_camera.position.y)); 
            _loseWindow.gameObject.SetActive(true);
            _gameController.SetActive(false);
            _gameGenerator.SetActive(false); 
        }
    }
}
