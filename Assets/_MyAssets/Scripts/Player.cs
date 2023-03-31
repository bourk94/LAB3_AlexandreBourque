using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Attribut
    [SerializeField] private float _vitesse = 600;
    [SerializeField] private Vector3 _positionDepart = new Vector3(-44f, 1f, -44f);
    private Rigidbody _rb;

    //Methodes privees
    private void Start()
    {
        //Postion de depart du joueur
        this.transform.position = _positionDepart;
        _rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        MouvementsJoueur();
    }

    private void MouvementsJoueur()
    {
        float positionX = Input.GetAxis("Horizontal");
        float positionZ = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(positionX, 0f, positionZ);
        _rb.velocity = direction * Time.fixedDeltaTime * _vitesse;
    }

    // Methode publiques
    public void FinPartie()
    {
        this.gameObject.SetActive(false);
    }
}
