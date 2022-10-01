using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public GameObject startMenuUI;



    void start()
    {

    }

    public void Awake()
    {
        startMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startMenuUI.SetActive(false);
            Time.timeScale = 1f;
            this.enabled= false;

        }


    }

    
   

    

    
}
