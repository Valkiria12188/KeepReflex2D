using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool isPointBox = false;
    public GameObject impactEffect;

    private void Update()
    {
        Destroy();
    }

    public void OnPointDestroy()
    {
        if (isPointBox)
        {
            GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effect, 2f);
            Destroy(gameObject);
        }
    }

    private void Destroy()
    {
        if (transform.position.y <= -9)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject != null)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnPointDestroy();
            }
        }
    }

}