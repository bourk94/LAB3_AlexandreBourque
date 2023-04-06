using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AffichageFinal : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtTempsTotal = default;
    [SerializeField] private TMP_Text _txtAccorchagesTotal = default;
    [SerializeField] private TMP_Text _txtPointageTotal = default;
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _txtTempsTotal.text = "Temps Total : " + _gameManager.GetTempsFinal().ToString("f2") + " secondes";
        _txtAccorchagesTotal.text = "Nombres d'accrochages : " + _gameManager.GetPointage().ToString();
        float pointageTotal = _gameManager.GetTempsFinal() + _gameManager.GetPointage();
        _txtPointageTotal.text = "Pointage Final : " + pointageTotal.ToString("f2") + " secondes";
    }
}
