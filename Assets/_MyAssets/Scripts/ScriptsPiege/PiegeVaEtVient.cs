using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiegeVaEtVient : MonoBehaviour
{
    [SerializeField] private float _vitesse = 0f;
    [SerializeField] private Vector3 _pointA = new Vector3(0f, 0f, 0f);
    [SerializeField] private Vector3 _pointB = new Vector3(0f, 0f, 0f);

    void Update()
    {
        float time = Mathf.PingPong(Time.time * _vitesse, 1);
        transform.localPosition = Vector3.Lerp(_pointA, _pointB, time);
    }
}
