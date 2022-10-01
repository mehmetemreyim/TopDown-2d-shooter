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

    //Merminin 2 saniye sonra yokolmas�n� sa�lar
    public void Update()
    {
        Destroy(gameObject, 2f);
    }

    //mermi de�dikten sonraki i�lemler

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") {
                Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
                
                Instantiate(impactEffect2, transform.position, Quaternion.identity);
                ScreenShake.instance.StartShake(0.25f, 0.25f); //mermi d��man� yoketti�inde titresmesi i�in
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
