using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavArrow : MonoBehaviour
{
    private GameObject target;

    private void Start()
    {
        target = FindObjectOfType<Three>().gameObject;
    }
    void Update()
    {
        Vector3 targetPosition = target.transform.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);
    }

    public void LookThree()
    {
        target = FindObjectOfType<Three>().gameObject;
    }

    public void QuestOneAccept()
    {
        target = FindObjectOfType<Garden>().gameObject;
    }

    public void QuestTwoAccept()
    {
        target = FindObjectOfType<Garden>().gameObject;
    }

    public void QuestTreeAccept()
    {
        target = FindObjectOfType<Garden>().gameObject;
    }
}
