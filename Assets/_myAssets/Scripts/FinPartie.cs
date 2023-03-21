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

            if (noScene == 0)
            {
                _gestionJeu.SetNiveau1(_gestionJeu.GetPointage(), Time.time);
                SceneManager.LoadScene(noScene + 1);
                _finPartie = false;
            }
            else if (noScene == 1)
            {
                _gestionJeu.SetNiveau2((_gestionJeu.GetPointage() - _gestionJeu.GetAccrochagesNiveau1()), (Time.time - _gestionJeu.GetTempsNiveau1()));
                SceneManager.LoadScene(noScene + 1);
                _finPartie = false;
            }
            else if (noScene == 2)
            {
                int accrochages = _gestionJeu.GetPointage();
                float _tempsTotalNiveau1 = _gestionJeu.GetTempsNiveau1() + _gestionJeu.GetAccrochagesNiveau1();
                float _tempsTotalNiveau2 = _gestionJeu.GetTempsNiveau2() + _gestionJeu.GetAccrochagesNiveau2();
                float _tempsNiveau3 = Time.time - (_gestionJeu.GetTempsNiveau1() + _gestionJeu.GetTempsNiveau2());
                int _accrochagesNiveau3 = _gestionJeu.GetPointage() - (_gestionJeu.GetAccrochagesNiveau1() + _gestionJeu.GetAccrochagesNiveau2());
                float _tempsTotalNiveau3 = _tempsNiveau3 + _accrochagesNiveau3;

                Debug.Log("Fin de la partie!");
                Debug.Log("Le temps pour le niveau 1 est de "  + _gestionJeu.GetTempsNiveau1().ToString("f2") + " secondes");
                Debug.Log("Vous avez accoché au niveau 1 " + _gestionJeu.GetAccrochagesNiveau1() + " obstacles");
                Debug.Log("Votre temps total est de : " + _tempsTotalNiveau1.ToString("f2") + "secondes");
                Debug.Log("Le temps pour le niveau 2 est de "  + _gestionJeu.GetTempsNiveau2().ToString("f2") + " secondes");
                Debug.Log("Vous avez accoché au niveau 2 " + _gestionJeu.GetAccrochagesNiveau2() + " obstacles");
                Debug.Log("Votre temps total est de : " + _tempsTotalNiveau2.ToString("f2") + "secondes");
                Debug.Log("Le temps pour le niveau 3 est de "  + _tempsNiveau3.ToString("f2") + " secondes");
                Debug.Log("Vous avez accoché au niveau 3 " + _accrochagesNiveau3 + " obstacles");
                Debug.Log("Votre temps total est de : " + _tempsTotalNiveau3.ToString("f2") + "secondes");
                Debug.Log("Votre temps total pour les trois niveaux est de" + (_tempsTotalNiveau1 + _tempsTotalNiveau2 + _tempsTotalNiveau3).ToString("f2") + "secondes");

                _player.finPartieJoueur();
            }
        }
    }
}
