using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterHareket : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D myBody;
    private Vector2 moveVelocity;
    [SerializeField]
    private int maxHealth = 5;
    public int currentHealth;
    public GameObject can1, can2, can3, can4, can5, mainMenuUI;
    public int damage = 1;
    public AudioSource vurulmaSesi;
    public void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        mainMenuUI.SetActive(false);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Time.timeScale = 0f;
        }
    }

    public void FixedUpdate()
    {
        Movement();
        Rotation();
    }


    void Movement()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * moveSpeed;
        myBody.MovePosition(myBody.position + moveVelocity * Time.fixedDeltaTime);


    }

    void Rotation()
    {
        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 90 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (collision != null)
            {
                ScreenShake.instance.StartShake(0.25f, 0.25f); //mermi düþmaný yokettiðinde titresmesi için
                TakeDamage(damage);
            }
        }

    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth == 4)
        {
            vurulmaSesi.Play();
            can5.SetActive(false);
        }

        if (currentHealth == 3)
        {
            vurulmaSesi.Play();
            can4.SetActive(false);
        }

        if (currentHealth == 2)
        {
            vurulmaSesi.Play();
            can3.SetActive(false);
        }

        if (currentHealth == 1)
        {
            vurulmaSesi.Play();
            can2.SetActive(false);
        }

        if (currentHealth == 0)
        {
            vurulmaSesi.Play();
            mainMenuUI.SetActive(true);
            can1.SetActive(false);
            Time.timeScale = 0f;
        }
    }

}
