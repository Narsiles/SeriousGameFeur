using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [SerializeField] FloatingJoystick joystick;

    Vector3 moveDirection;
    Vector3 aimDirection;
    float moveSpeed = 0;
    [SerializeField] float speedMax = 10f;
    [SerializeField] float acceleration = 0.1f;
    [SerializeField] float decceleration = 0.1f;
    [SerializeField] float smoothRotation = 0.1f;

    //[SerializeField] float fireRate;

    // Cache
    Rigidbody rb;
    GameManager gameManager;
    private bool isTrigger = false;
    private GameObject target;
    [SerializeField] private int strength = 200;
    private bool haveShowel = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (joystick.Direction.magnitude > 0)
        {
            // Vecteur de direction de déplacement
            moveDirection = new Vector3(joystick.Direction.x, 0, joystick.Direction.y).normalized;
            moveSpeed = Mathf.Lerp(moveSpeed, speedMax, acceleration) * joystick.Direction.magnitude;

        } else {
            moveSpeed = Mathf.Lerp(moveSpeed, 0, decceleration);
        }
       
       
        if (isTrigger)
        {
            transform.LookAt(target.transform.position);
        }
        else
        {
            // Orientation du player
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, smoothRotation);
            aimDirection = moveDirection;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isTrigger = true;
            target = other.gameObject;
            TryToShoot(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isTrigger = false;
        }
    }

    private void FixedUpdate()
    {
        // Vélocité = direction * vitesse * inclinaison du joystick
        rb.velocity = moveDirection * moveSpeed;

    } 
    void TryToShoot(GameObject targetfunction)
    {
        if(haveShowel == true)
        {
            targetfunction.GetComponent<Enemy>().IsTouch();
            targetfunction.GetComponent<Rigidbody>().AddForce(-targetfunction.transform.forward * strength, ForceMode.Impulse);
            
        }
    }

    public void TakeShowel()
    {
        haveShowel = true;
    }
}
