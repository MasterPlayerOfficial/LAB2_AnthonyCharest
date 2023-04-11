using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinPartie : MonoBehaviour
{
    private GestionJeu _gestionJeu;
    private PlayerScript _player;

    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _player = FindObjectOfType<PlayerScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "Player")  // Si la collision est produite avec le joueur et la partie n'est pas termin�e
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;  // on change la couleur du mat�riel � vert
            int noScene = SceneManager.GetActiveScene().buildIndex; // R�cup�re l'index de la sc�ne en cours
            if (noScene == (SceneManager.sceneCountInBuildSettings - 2))  // Si nous somme sur le dernier niveau de jeu
            {
                _player.finPartieJoueur();
                _gestionJeu.SetTempsFinal(Time.time);
                SceneManager.LoadScene(noScene + 1);
            }
            else
            {
                // Appelle la m�thode publique dans gestion jeu pour conserver les informations du niveau 1
                //_gestionJeu.SetNiveau1(_gestionJeu.GetPointage(), Time.time);
                // Charge la sc�ne suivante
                SceneManager.LoadScene(noScene + 1);            
            }
        }
    }
}
