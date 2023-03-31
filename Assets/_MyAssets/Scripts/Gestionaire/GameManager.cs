using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Attributs

    private int _pointage = 0;  // Attribut qui conserve le nombre d'accrochages
    private int _accrochage = 0;  // Atribut qui conserve le nombre d'accrochage
    private float _temps = 0.0f;  // Attribut qui conserve le temps

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
        InstructionsDepart();  // Affiche les instructions de départ
    }

    
     // Méthode qui affiche les instructions au départ
    private static void InstructionsDepart()
    {
        Debug.Log("Course à obstacles");
        Debug.Log("Le but du jeu est d'atteindre la zone d'arrivée le plus rapidement possible dans les 3 niveaux");
        Debug.Log("Chaque contact avec un obstable entraînera une pénalité de temps de 1 seconde");
    }

    // Méthodes publiques

    
    // Méthode publique qui permet d'augmenter le pointage de 1
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
