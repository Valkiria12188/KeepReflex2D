using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform rotationCenter;
    private float posX, posY, angle = 0f;
    [SerializeField] private float rotationRadius = 1.35f;
    [SerializeField] public float angularSpeed = 2f;
    [SerializeField] private GameObject impactEffect;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;

        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;
        if (angle >= 360)
        {
            angle = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            angularSpeed = -angularSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject != null)
        {
            if (other.gameObject.CompareTag("ScoringBox"))
            {
                FindObjectOfType<GameManager>().IncreaseScore();
                IncreaseSpeed();
            }
            if (other.gameObject.CompareTag("EnemyBox"))
            {
                FindObjectOfType<GameManager>().DelayGameOver();
                OnPointDestroy();
            }
        }
    }

    private void IncreaseSpeed()
    {
        if (gameManager.score > 0 && gameManager.score % 5 == 0)
        {
            float x = Mathf.Abs(angularSpeed) + 1;
            angularSpeed = x;
        }
    }

    public void OnPointDestroy()
    {
        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
        Destroy(gameObject);

    }
}
