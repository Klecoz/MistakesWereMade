using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightBoxLightController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOnLava()
    {
        StartCoroutine(StartDelayedFire());
    }


    IEnumerator StartDelayedFire()
    {
        yield return new WaitForSeconds(2);
        Light lavalight = GetComponent<Light>();
        lavalight.enabled = true;
        AudioSource lavaaudio = GetComponent<AudioSource>();
        lavaaudio.Play();
        yield return new WaitForSeconds(1);
        lavalight.intensity = 10f;
        yield return new WaitForSeconds(1);
        lavalight.intensity = 40f;
        yield return new WaitForSeconds(1);
        lavalight.intensity = 90f;
        yield return new WaitForSeconds(1);
        lavalight.intensity = 130f;
        SceneManager.LoadScene("MistakesWereMade");
    }
}
