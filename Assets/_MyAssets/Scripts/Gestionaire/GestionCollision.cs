using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollision : MonoBehaviour
{
    // Attributs
    private GameManager _gameManager;
    private bool _toucher;
    private float _delais = 4;
    private float _tempsDepart;
    private Color _color;


    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _toucher = false;
    }

    private void Update()
    {
        // Si l'obstacle est touché et que le délais est dépassé, on remet la couleur de base
        if (_toucher && Time.time > _tempsDepart + _delais)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = _color;
            _toucher = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {      
        if (!_toucher && collision.gameObject.tag == "Player")
        {
            _color = gameObject.GetComponent<MeshRenderer>().material.color;
            _tempsDepart = Time.time;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            _gameManager.AugmenterPointage();
            _toucher = true;            
        }  
    }
}
