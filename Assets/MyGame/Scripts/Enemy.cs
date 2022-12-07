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
    [SerializeField] int lifePoint = 3;

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
    
    public void IsTouch(int damage, int strength, Transform t)
    {
        
        if(lifePoint <= 0)
        {
            //GetComponent<Rigidbody>().AddForce(t.forward * strength);
            Invoke("Death", 2f);
            isAlive = false;
        }
        else
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(t.forward.x + 10, t.forward.y + 5, t.forward.z) / 2, ForceMode.Impulse);
            lifePoint -= damage;
        }
        
        
    }

    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x - 10, transform.forward.y + 5, transform.forward.z) / 2, ForceMode.Impulse);
    }

    private void Death()
    {
        Destroy(gameObject);
        FindObjectOfType<GameManager>().CheckWave();
    }

}
