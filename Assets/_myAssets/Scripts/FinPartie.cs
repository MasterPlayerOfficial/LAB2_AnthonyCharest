using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinPartie : MonoBehaviour
{
    private bool _finPartie = false;
    private GestionJeu _gestionJeu;
    private PlayerScript _player;

    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _player = FindObjectOfType<PlayerScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_finPartie)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            _finPartie = true;
            int noScene = SceneManager.GetActiveScene().buildIndex;

            if (noScene == 2)
            {
                int accrochages = _gestionJeu.GetPointage();
                Debug.Log("Fin de partie!");
                Debug.Log("Le temps est de "  + Time.time + " secondes");
                Debug.Log("Vous avez accoché " + accrochages + " obstacles");
                float tempsTotal = Time.time + accrochages;
                Debug.Log("Votre temps total est de : " + tempsTotal);
                _player.finPartieJoueur();
            }
            else
            {
                SceneManager.LoadScene(noScene + 1);
            }
        }
    }
}
