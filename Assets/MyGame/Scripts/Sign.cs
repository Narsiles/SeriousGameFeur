using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    [SerializeField] GameObject signUI;
    [SerializeField] ParticleSystem fx;

    private bool fxActive = true;


    private void OnTriggerEnter(Collider other)
    {
        if (fxActive == true)
        {
            if (other.CompareTag("Player"))
            {
                signUI.SetActive(true);
                fx.Stop();
                Time.timeScale = 0;
                fxActive = false;
            }
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                signUI.SetActive(true);              
                Time.timeScale = 0;
            }
        }
        
    }

}
