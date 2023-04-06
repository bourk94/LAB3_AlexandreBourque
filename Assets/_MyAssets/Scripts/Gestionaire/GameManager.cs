using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Attributs

    private int _pointage = 0;
    private float _tempsDepart = 0;
    private float _tempsFinal = 0;
    private float _temps = 0;

    // Méthodes privées
    private void Awake()
    {
        // Vérifie si un gameObject GameManager est déjà présent sur la scène si oui
        // on détruit celui qui vient d'être ajouté. Sinon on le conserve pour la 
        // scène suivante.
        int nbGameManager = FindObjectsOfType<GameManager>().Length;
        if (nbGameManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        _tempsDepart = Time.time;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
    }

    // Méthode publique qui permet d'augmenter le pointage de 1
    public void AugmenterPointage()
    {
        _pointage++;
        UIManager uiManager = FindObjectOfType<UIManager>();
        uiManager.ChangerPointage(_pointage);
    }

    public int GetPointage()
    {
        return _pointage;
    }

    public float GetTempsDepart()
    {
        return _tempsDepart;
    }

    public void SetTemps(float __temps)
    {
        _temps = __temps;
    }

    public float GetTemps() 
    { 
        return _temps; 
    }

    public void SetTempsFinal(float __tempFinal)
    {
        _tempsFinal = __tempFinal;
    }

    public float GetTempsFinal()
    {
        return _tempsFinal;
    }
}
