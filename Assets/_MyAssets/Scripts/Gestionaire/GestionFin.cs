using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionFin : MonoBehaviour
{
    // Attributs
    private GameManager _gameManager;
    private bool _toucher;
    private Player _player;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _toucher = false;
        _player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (_toucher && collision.gameObject.tag != "Player")
        {
            return;
        }

        int indexScene = SceneManager.GetActiveScene().buildIndex;
        _player.FinPartie();
        _toucher = true;
        
        if (indexScene == (SceneManager.sceneCountInBuildSettings - 2))
        {
            _gameManager.SetTempsFinal(Time.time);
            SceneManager.LoadScene(indexScene + 1);
        }
        else
        {
            SceneManager.LoadScene(indexScene + 1);
        }
    }
}
