using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitShot : MonoBehaviour
{
    public AudioClip HitSound = null;
    public GameObject BeamPrefab = null;
    public float damage = 25;
    public Animator animator;

    private Rigidbody2D rigifbody;
    private bool isHit = false;
    private bool hited = false;
    // Start is called before the first frame update
    void Start()
    {
       
        rigifbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        RotationFall();
    }

    private void RotationFall()
    {
        if (isHit == false)
        {
            Vector2 velocityVector = rigifbody.velocity;
            float fallAngle = Mathf.Atan(velocityVector.y / velocityVector.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0f, 0f, fallAngle);
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hited == false && isHit == false)
        {
            hit();
            MakeDamage(collision.gameObject.GetComponent<DamageHit>());
            
        }
        
    }

    private void MakeDamage(DamageHit theTarget)
    {
        if (theTarget && hited == false)
        {
            hited = true;
            theTarget.GetDamage(damage);
            if (BeamPrefab) Instantiate(BeamPrefab, transform.position, Quaternion.identity);
            transform.parent = theTarget.gameObject.transform;
        }
    }

    private void hit()
    {
        isHit = true;
        EmbedBihavior();
        if (HitSound) AudioSource.PlayClipAtPoint(HitSound, transform.position, 1f);
        animator.SetBool("isHit", true);
        Destroy(gameObject, 6f);
    }

    private void EmbedBihavior()
    {
        rigifbody.isKinematic = true;
        rigifbody.velocity = Vector3.zero;
        rigifbody.freezeRotation = true;
    }
}
