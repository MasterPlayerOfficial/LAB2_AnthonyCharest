using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiegeScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listePieges = new List<GameObject>();
    [SerializeField] private float _intensiteForce = 500;
    private List<Rigidbody> _listeRb = new List<Rigidbody>();
    private bool _estActive = false;

    private void Awake()
    {
        foreach(var piege in _listePieges)
        {
        _listeRb.Add(piege.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !_estActive)
        {
            foreach(var rb in _listeRb)
            {
            rb.useGravity = true;
            Vector3 direction = new Vector3(0f, -1f, 0f);
            rb.AddForce(direction * _intensiteForce);
            }
        }
        _estActive = true;
    }
}
