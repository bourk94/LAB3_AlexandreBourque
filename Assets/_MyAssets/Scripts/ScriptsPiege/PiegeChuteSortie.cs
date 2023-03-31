using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiegeChuteSortie : MonoBehaviour
{
    // Attributs
    private bool _estActive = false;
    [SerializeField] private List­<GameObject> _listePieges = new List<GameObject>();
    [SerializeField] private float _force;
    private List<Rigidbody> _listeRb = new List<Rigidbody>();


    private void Start()
    {
        foreach (var piege in _listePieges)
        {
            piege.GetComponent<Rigidbody>().useGravity = false;
            _listeRb.Add(piege.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_estActive && other.gameObject.tag == "Player")
        {
            foreach (var rb in _listeRb)
            {
                rb.useGravity = true;
                rb.AddForce(Vector3.down * _force);
            }
            _estActive = true;
        }
    }
}
