using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Attributs

    private int _pointage = 0;  // Attribut qui conserve le nombre d'accrochages
    private int _accrochage = 0;  // Atribut qui conserve le nombre d'accrochage
    private float _temps = 0.0f;  // Attribut qui conserve le temps

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
        InstructionsDepart();  // Affiche les instructions de d�part
    }

    
     // M�thode qui affiche les instructions au d�part
    private static void InstructionsDepart()
    {
        Debug.Log("Course � obstacles");
        Debug.Log("Le but du jeu est d'atteindre la zone d'arriv�e le plus rapidement possible dans les 3 niveaux");
        Debug.Log("Chaque contact avec un obstable entra�nera une p�nalit� de temps de 1 seconde");
    }

    // M�thodes publiques

    
    // M�thode publique qui permet d'augmenter le pointage de 1
    public void AugmenterPointage()
    {
        _pointage++;
    }

    public int GetPointage()
    {
        return _pointage;
    }

    public float GetTempsNiv1()
    {
        return _temps;
    }

    public int GetAccrochagesNiv1()
    {
        return _accrochage;
    }

    public void SetNiveau1(int accrochages, float temps)
    {
        _accrochage = accrochages;
        _temps = temps;
    }

    public float GetTempsNiv2()
    {
        return _temps;
    }

    public int GetAccrochagesNiv2()
    {
        return _accrochage;
    }

    public void SetNiveau2(int accrochages, float temps)
    {
        _accrochage = accrochages;
        _temps = temps;
    }

    public float GetTempsNiv3()
    {
        return _temps;
    }

    public int GetAccrochagesNiv3()
    {
        return _accrochage;
    }

    public void SetNiveau3(int accrochages, float temps)
    {
        _accrochage = accrochages;
        _temps = temps;
    }
}
