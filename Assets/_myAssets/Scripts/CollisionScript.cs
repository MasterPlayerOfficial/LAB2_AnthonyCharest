using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    private GestionJeu _gestionJeu;
    private bool _touche;

    private void Start()
    {
        _touche = false;
        _gestionJeu = FindObjectOfType<GestionJeu>();
    }

    private IEnumerator OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_touche)
        {
            _touche = true;
            GetComponent<MeshRenderer>().material.color = Color.red;
            _gestionJeu.AugmenterPointage();

            yield return new WaitForSeconds(4f);
            _touche = false;
            GetComponent<MeshRenderer>().material.color = Color.green;
            yield return null;
        }
    }
}
