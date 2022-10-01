using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi : MonoBehaviour
{
    public static Mermi instance;
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public GameObject impactEffect2;
    


    void Start()
    {
        rb.velocity = transform.right * speed;
        
    }

    //Merminin 2 saniye sonra yokolmasýný saðlar
    public void Update()
    {
        Destroy(gameObject, 2f);
    }

    //mermi deðdikten sonraki iþlemler

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") {
                Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
                
                Instantiate(impactEffect2, transform.position, Quaternion.identity);
                ScreenShake.instance.StartShake(0.25f, 0.25f); //mermi düþmaný yokettiðinde titresmesi için
                enemy.TakeDamage(damage);
                
            }
        
        Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Duvar")
        {
            
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
        }

    }


}
