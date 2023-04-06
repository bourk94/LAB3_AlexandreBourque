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

    // M�thodes priv�es
    private void Awake()
    {
        // V�rifie si un gameObject GameManager est d�j� pr�sent sur la sc�ne si oui
        // on d�truit celui qui vient d'�tre ajout�. Sinon on le conserve pour la 
        // sc�ne suivante.
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

    // M�thode publique qui permet d'augmenter le pointage de 1
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
