using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource deathSound;
    public GameObject shot;
    public Transform playerBulletSpawn;
    public float fireRate;
    public float moveSpeed;
    public int life;
    public Rigidbody2D rb;
    public Camera MainCamera; 
    private Vector2 moveDirection;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private float nextFire;

    // get the main camera and player's size
    void Start()
    {
        deathSound = GetComponent<AudioSource>();
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 
                                                            transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        Fire();
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    private void LateUpdate()
    {
        Boundaries();
    }

    // Boundaries function
    private void Boundaries()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth); 
        viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight); 
        transform.position = viewPos;
    }

    private void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void Fire()
    {
        if ((Input.GetButton("Fire1") && Time.time > nextFire)) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, playerBulletSpawn.position, playerBulletSpawn.rotation);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        deathSound.Play();
        life = life - 1;
        if (life <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    
}
