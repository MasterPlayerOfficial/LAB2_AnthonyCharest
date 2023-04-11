using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    [SerializeField] private GameObject _menuInstructions;

    public void OuvrirInstructions()
    {
        _menuInstructions.SetActive(true);
    }

    public void FermerIntructions()
    {
        _menuInstructions.SetActive(false);
    }
}