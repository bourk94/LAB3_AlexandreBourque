using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb = default;
    [SerializeField] private TMP_Text _txtAccrochages = default;
    [SerializeField] private TMP_Text _txtTemps = default;
    [SerializeField] private GameObject _menuPause = default;
    private bool _enPause;
    private GameManager _gameManager;
    private Vector3 _positionDepart = Vector3.zero;
    private float _temps;
    private float _tempsAjuste;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _txtAccrochages.text = "Accrochages\n" + _gameManager.GetPointage();
        Time.timeScale = 1;
        _enPause = false;
        _menuPause.SetActive(false);
        _positionDepart = _rb.position;
        _tempsAjuste = _gameManager.GetTemps();
    }


    private void Update()
    {
        GestionTemps();
        GestionPause();     
    }

    private void GestionTemps()
    {
        _txtTemps.text = "Temps\n" + _tempsAjuste.ToString("f2");
        if (_rb.position == _positionDepart)
        {
            _temps = Time.time - _gameManager.GetTempsDepart() - _tempsAjuste;
        }
        if (_rb.position != _positionDepart)
        {
            _tempsAjuste = Time.time - (_gameManager.GetTempsDepart() + _temps);
            _txtTemps.text = "Temps\n" + _tempsAjuste.ToString("f2");
            _gameManager.SetTemps(_tempsAjuste);
        }
    }

    private void GestionPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_enPause)
        {
            _menuPause.SetActive(true);
            Time.timeScale = 0;
            _enPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _enPause)
        {
            EnleverPause();
        }
    }

    public void ChangerPointage(int __pointage)
    {
        _txtAccrochages.text = "Accrochages\n" + __pointage.ToString();
    }

    public void EnleverPause()
    {
        _menuPause.SetActive(false);
        Time.timeScale = 1;
        _enPause = false;
    }
}
