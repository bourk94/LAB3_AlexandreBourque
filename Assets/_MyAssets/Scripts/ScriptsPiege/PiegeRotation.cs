using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiegeRotation : MonoBehaviour
{
    // Attributs
    [SerializeField] private Vector3 _vitesse = new Vector3(0f, 0f, 0f);

    void FixedUpdate()
    {
        transform.Rotate(_vitesse);
    }
}
