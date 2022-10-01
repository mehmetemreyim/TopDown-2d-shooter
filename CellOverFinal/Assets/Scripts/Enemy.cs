using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public int health=100;
    public GameObject deathEffect;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        
    }
    
    void Update()
    {
        
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        moveCharacter(movement);
        
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    //Hasar alma ve ölme yeri
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
            Skor.instance.puanKazan();
        }
    }

    void Die()
    {
        Instantiate(deathEffect,transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    //Yaratiklarýn Colliderini 5 saniyeliðine kapat
    

}
