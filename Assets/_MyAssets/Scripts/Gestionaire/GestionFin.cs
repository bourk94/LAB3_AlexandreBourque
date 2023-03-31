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

        switch (indexScene)
        {
            case 0:
                _gameManager.SetNiveau1(_gameManager.GetPointage(), Time.time);
                Debug.Log("Fin du niveau 1");
                Debug.Log("Le temps pour le niveau 1 est de : " + _gameManager.GetTempsNiv1().ToString("f2") + " secondes");
                Debug.Log("Vous avez accroché au niveau 1 : " + _gameManager.GetAccrochagesNiv1() + " obstacles");
                Debug.Log("Temps total niveau 1 : " + (_gameManager.GetTempsNiv1() + _gameManager.GetAccrochagesNiv1()).ToString("f2") + " secondes");
                SceneManager.LoadScene(indexScene + 1);
                break;

            case 1:
                _gameManager.SetNiveau2(_gameManager.GetPointage() - _gameManager.GetAccrochagesNiv1(), Time.time - _gameManager.GetTempsNiv1());
                Debug.Log("Fin du niveau 2");
                Debug.Log("Le temps pour le niveau 2 est de : " + _gameManager.GetTempsNiv2().ToString("f2") + " secondes");
                Debug.Log("Vous avez accroché au niveau 2 : " + _gameManager.GetAccrochagesNiv2() + " obstacles");
                Debug.Log("Temps total niveau 2 : " + (_gameManager.GetTempsNiv2() + _gameManager.GetAccrochagesNiv2()).ToString("f2") + " secondes");
                SceneManager.LoadScene(indexScene + 1);
                break;

            case 2:
                float tempsTotal = Time.time + _gameManager.GetPointage();
                _gameManager.SetNiveau3(_gameManager.GetPointage() - (_gameManager.GetAccrochagesNiv2() + _gameManager.GetAccrochagesNiv1()), Time.time - (_gameManager.GetTempsNiv2() + _gameManager.GetTempsNiv1()));
                Debug.Log("Fin du niveau 3");
                Debug.Log("Le temps pour le niveau 3 est de : " + _gameManager.GetTempsNiv3().ToString("f2") + " secondes");
                Debug.Log("Vous avez accroché au niveau 3 : " + _gameManager.GetAccrochagesNiv3() + " obstacles");
                Debug.Log("Temps total niveau 3 : " + (_gameManager.GetTempsNiv3() + _gameManager.GetAccrochagesNiv3()).ToString("f2") + " secondes");
                Debug.Log("Temps total de la partie est de : " + tempsTotal.ToString("f2"));
                break;
        }
    }
}
