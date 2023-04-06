using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{
    [SerializeField] private GameObject _menuInstructions = default;
    public void ChangerSceneSuivante()
    {
        int noScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(noScene + 1);
    }

    public void QuitterJeu()
    {
        Application.Quit();
    }

    public void RetourMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void OuvrirMenuInstruction()
    {
        if (_menuInstructions.activeSelf)
        {
            _menuInstructions.SetActive(false);
        }
        else
        {
            _menuInstructions.SetActive(true);
        }
    }
}
