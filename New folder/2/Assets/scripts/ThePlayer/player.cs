using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [Header("mouve")]
    [SerializeField] float movespeed = 1f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float sensitiveHorizontal = 0.5f;
    [Header("info")]
    [SerializeField] int Health = 1000;
    [Header("Sound")]
    [SerializeField] AudioClip DeathSound = null;
    [SerializeField] AudioClip jumpSound = null;
    [Header("Other")]
    [SerializeField] Joystick joystick = null;
    [SerializeField] Animator animator = null;
    [SerializeField] shot theShot = null;
    

    private bool isJumped = false;
    private bool isMouve = false;
    private bool isDeath = false;

    private void Start()
    {
        
    }
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            theShot.Fire(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            theShot.Fire(false);
        }
    }

    private void JoystivkMouve()
    {
        if (isMouve == true)
        { 
            float DeltaX = 0f;
            if (joystick.Horizontal > sensitiveHorizontal)
            {
                DeltaX = Time.deltaTime * movespeed;
                animator.SetBool("IsWalk", true);
            }
            else if (joystick.Horizontal < -sensitiveHorizontal)
            {
                DeltaX = -Time.deltaTime * movespeed;
                animator.SetBool("IsWalk", true);
            }
            else if (joystick.Horizontal == 0)
            {
                animator.SetBool("IsWalk", false);
            }
		    transform.position = new Vector2 (transform.position.x + DeltaX, transform.position.y);
            
        }
    }
    
    public void Jump()
    {
        if (isJumped == false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, jumpForce);
            AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position, 1f);
            animator.SetBool("IsJump", true);
            isJumped = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var damage = collision.gameObject.GetComponent<ShotInfo>();
        if (collision.gameObject.GetComponent<ShotInfo>())
        {
            Health -= damage.damage;
            if (Health <= 0 && isDeath == false)
            {
                Death();
            }
        }
    }

    private void Death()
    {
        AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position, 1f);
        animator.SetBool("IsDeath", true);
        Destroy(gameObject,2);
        isDeath = true;
        SceneManager.LoadScene(0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumped = false;
        animator.SetBool("IsJump", false);
    }
}

/*
 * old scripte
 
    private void Fire()
    {
    if (Input.GetMouseButtonDown(0))
        {
           FindObjectOfType<shot>().Fire(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            FindObjectOfType<shot>().Fire(allowfire);
        }
        if (isWalk == false)
        {
            FindObjectOfType<shot>().Fire(allowfire);
        }
    }

 * 
 */
