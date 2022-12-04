using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] GameObject[] garden;
    [SerializeField] GameObject player;

    [SerializeField] private float rangeVision = 5;
    private float distanceBetween = 1000000;
    private bool isAlive = true;
    
    private void Start()
    {
        garden = GameObject.FindGameObjectsWithTag("Garden");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void ChooseTarget()
    {
        for(int i = 0; i < garden.Length; i++)
        {
            if (Vector3.Distance(garden[i].transform.position, transform.position) < distanceBetween)
            {
                target = garden[i].transform;
                distanceBetween = Vector3.Distance(garden[i].transform.position, transform.position);
            }
        }
    }

    void Update()
    {

        if (Vector3.Distance(player.transform.position, transform.position) < rangeVision)
        {
            target = player.transform;
        }
        else
        {
            ChooseTarget();
        }

        if (isAlive)
        {
           GetComponent<NavMeshAgent>().destination = target.position;
        }
       
    }
    
    public void IsTouch()
    {     
        Invoke("Death", 2f);
        isAlive = false;
    }

    private void Death()
    {
        Destroy(gameObject);
        FindObjectOfType<GameManager>().CheckWave();
    }

}
