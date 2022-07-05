using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public AudioClip Explosion;
    public GameObject Asteroide;

    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(Explosion, transform.position);
        Destroy(this.gameObject);
    }
}