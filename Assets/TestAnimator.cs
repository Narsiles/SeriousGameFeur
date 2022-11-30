using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimator : MonoBehaviour
{
    [SerializeField] float speed = 0;
    [SerializeField] bool sm = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetBool("sm", sm);
        GetComponent<Animator>().SetFloat("speed", speed);
    }
}
