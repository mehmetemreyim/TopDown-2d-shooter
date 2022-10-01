using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float minSure, maxSure;
    public GameObject[] objelerListesi;

    void Update()
    {
        if (objeSpawnCoroutine == null)
        {
            objeSpawnCoroutine = StartCoroutine(objeSpawn(Random.Range(minSure, maxSure)));
        }
    }

    Coroutine objeSpawnCoroutine = null;
    IEnumerator objeSpawn(float zaman)
    {
        int rastgeleSayi = Random.Range(0, objelerListesi.Length);
        GameObject objeler = Instantiate(objelerListesi[rastgeleSayi], gameObject.transform.position + new Vector3(Random.Range(0, 3.5f), 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(zaman);
        objeSpawnCoroutine = null;
    }
} 
