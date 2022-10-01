using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silah : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    bool durdu;
    public GameObject pauseMenuUI;
    

    public void Start()
    {
        durdu = false;
        
    }

    

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) & durdu ==     false)
        {
            Shoot();
        }

        if (Input.GetKeyDown("h") & durdu == false)
        {
            pauseMenuUI.SetActive(true);
            durdu = true;
            Time.timeScale = 0f;    
        }

        if (Input.GetKeyDown("p") & durdu == true)
        {
            pauseMenuUI.SetActive(false);
            durdu = false;
            Time.timeScale = 1f;
        }

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }


}
