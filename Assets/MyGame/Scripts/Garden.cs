using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour
{
    [SerializeField] private int lifePoint = 3;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lifePoint--;
            CheckLife();
        }
    }

    private void CheckLife()
    {
        if(lifePoint <= 0)
        {
            Debug.Log("loose");
        }
    }
}
