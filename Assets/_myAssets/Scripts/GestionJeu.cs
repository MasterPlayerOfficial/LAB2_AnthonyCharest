using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionJeu : MonoBehaviour
{
    private int _pointage;

    private void Start()
    {
        _pointage = 0;
    }

    public void AugmenterPointage()
    {
        _pointage++;
    }

    public int GetPointage()
    {
        return _pointage;
    }
}
