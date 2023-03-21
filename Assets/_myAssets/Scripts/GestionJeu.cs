using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionJeu : MonoBehaviour
{
    private int _pointage = 0;
    private int _accrochagesNiveau1 = 0;
    private float _tempsNiveau1 = 0.0f;
    private int _accrochagesNiveau2 = 0;
    private float _tempsNiveau2 = 0.0f;

    private void Awake()
    {
        int nbGestionJeu = FindObjectsOfType<GestionJeu>().Length;

        if (nbGestionJeu < 1)
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
        InstructionsDepart();
    }

    private static void InstructionsDepart()
    {
        Debug.Log("La course a obstacles");
        Debug.Log("Le but est simple: Atteindre la zone d'arrivée le plus rapidement possible");
        Debug.Log("Attention: Chaque contact avec un obstacle entraîne une pénalité");
    }

    public void AugmenterPointage()
    {
        _pointage++;
    }

    public int GetPointage()
    {
        return _pointage;
    }

    public int GetAccrochagesNiveau1()
    {
        return _accrochagesNiveau1;
    }

    public float GetTempsNiveau1()
    {
        return _tempsNiveau1;
    }

    public int GetAccrochagesNiveau2()
    {
        return _accrochagesNiveau2;
    }

    public float GetTempsNiveau2()
    {
        return _tempsNiveau2;
    }

    public void SetNiveau1(int accrochages, float tempsNiveau1)
    {
        _accrochagesNiveau1 = accrochages;
        _tempsNiveau1 = tempsNiveau1;
    }

    public void SetNiveau2(int accrochages, float tempsNiveau2)
    {
        _accrochagesNiveau2 = accrochages;
        _tempsNiveau2 = tempsNiveau2;
    }
}
