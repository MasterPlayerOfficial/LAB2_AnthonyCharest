using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    [SerializeField] private float _vitesse = 100.0f;
    private Rigidbody _rb;

    private void Start()
    {
        transform.position = new Vector3(-40f, 0.5f, -40f);
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MouvementsJoueur();
    }

    private void MouvementsJoueur()
    {
        float positionX = Input.GetAxis("Horizontal");
        float positionZ = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(positionX, 0f, positionZ);
        direction.Normalize();
        _rb.velocity = direction * Time.fixedDeltaTime * _vitesse;
        transform.forward = direction;
    }

    public void finPartieJoueur()
    {
        gameObject.SetActive(false);
    }
}
