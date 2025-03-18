using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePreFab;
    public Animator animator;
    public Transform fireSocket;
    public float rotationRate = 180.0f;
    public ParticleSystem fireFX;

    public int numProjectiles = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float aimInput = Input.GetAxis("Horizontal");
        aimInput *= rotationRate * Time.deltaTime;
        transform.Rotate(Vector3.right * aimInput, Space.World);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }
    
    void Fire()
    {
        animator.SetTrigger("Fire");
        Instantiate(projectilePreFab, fireSocket.position, fireSocket.rotation);

        fireFX.Play();

        numProjectiles++;
    }
}
