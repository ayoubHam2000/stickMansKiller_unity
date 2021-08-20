using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [Header("heath")]
    [SerializeField] float health = 100f;
    [Header("jump")]
    [SerializeField] float jumpForce = 10f;
    [SerializeField] bool allowJump = true;
    [Header("mouve")]
    [SerializeField] float mouveSpeed = 10f;
    [SerializeField] Transform paths = null;
    [SerializeField] Vector2 randomDistance = Vector2.zero;
    [Header("shot")]
    [SerializeField] shot TheGun = null;
    [SerializeField] Vector2 timebetween = Vector2.zero;
    [Header("autre")]
    [SerializeField] Animator animator = null;
    [SerializeField] Color effectColor = Color.black;
    [SerializeField] GameObject particuleEffect;
    // Start is called before the first frame update

    public List<Transform> path = null;
    public bool reachedToPosition = false;

    private Vector3 speed = Vector3.zero;
    private Vector3 initialPos = Vector3.zero;
    private int randomPath = 0;
    private bool shoting = true;
    private bool isDeath = false;
    private bool changeColor = false;
    private Color initialColor = Color.black;




    void Start()
    {
        initialPos = transform.position;
        initialColor = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color;
        InportPath();
        StartCoroutine(Jump());
    }

    void Update()
    {
        speed = transform.position - initialPos;
        initialPos = transform.position;
        animationControl();
        Biahvor();

    }

    private void Biahvor()
    {
        
        mouve(path[randomPath]);
        if (reachedToPosition == true)
        {
            randomPath = (int)Random.Range(0, path.Count);
            if (shoting == true)
            {
                StartCoroutine(shot());
                shoting = false;
            }
            
        }
    }

    private void mouve(Transform target)
    {
        if (reachedToPosition == false)
        {
            float randomDistanc = Random.Range(randomDistance.x, randomDistance.y);
            Vector2 newPos = new Vector2(target.position.x + randomDistanc , transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, newPos, mouveSpeed * Time.deltaTime);
            if (transform.position.x == newPos.x)
            {
                reachedToPosition = true;
            }
        }
    }

    private IEnumerator Jump()
    {
        while (true)
        {
            if (allowJump == true && speed.y == 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, jumpForce);
            }
            yield return new WaitForSeconds(Random.Range(3, 5));
        }
        
    }
    private IEnumerator shot()
    {
        while (true)
        {
            TheGun.Fire(true);
            yield return new WaitForSeconds(Random.Range(timebetween.x, timebetween.y));
            TheGun.Fire(false);
            yield return new WaitForSeconds(Random.Range(timebetween.x, timebetween.y));
        }

    }

    private void animationControl()
    {
        if (speed.x == 0) animator.SetBool("Idel", true);
        else animator.SetBool("Idel", false);

        if (speed.y > 0) animator.SetBool("IsJump", true);
        else animator.SetBool("IsJump", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var damage = collision.gameObject.GetComponent<ShotInfo>();
        if (collision.gameObject.GetComponent<ShotInfo>())
        {
            GetDamage(damage.damage);
        }
    }

    private void GetDamage(float TheDamge)
    {
        health -= TheDamge;
        if (changeColor == false)
        {
            ChangeColor(transform, 0, effectColor);
            Invoke("ResetColor", 0.1f);
            changeColor = true;
        }
        if (health < 0 && isDeath == false)
        {
            Death();
            isDeath = true;
        }
    }

    private void ResetColor()
    {
        ChangeColor(transform, 0, initialColor);
        changeColor = false;
    }

    private void ChangeColor(Transform TheTransform, int b, Color TheColor)
    {
        int i = TheTransform.childCount; 
        while (i > 0)
        {
            i--;
            if (TheTransform.GetChild(i).gameObject.GetComponent<SpriteRenderer>())
            {
                TheTransform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = TheColor;
                if (transform.GetChild(i).gameObject.transform.childCount != 0)
                {
                    ChangeColor(TheTransform.GetChild(i).gameObject.transform , ++b, TheColor);
                }
                
            }
            
            
        }
    }

    private void Death()
    {
        Instantiate(particuleEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    

    private void InportPath()
    {
        foreach (Transform child in paths)
        {
            path.Add(child);
        }
    }



    
}
/*
 * private void OnCollisionStay2D(Collision2D collision)
    {
        float collisionPos = collision.gameObject.transform.position.y;
        float objectPos = transform.position.y;
        float Dst = objectPos - collisionPos;
        if (Dst > 0)
        {
            onLand = true;
            animator.SetBool("IsJump", false);
        }
    }
*/