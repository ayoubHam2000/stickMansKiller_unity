using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotrycast : MonoBehaviour
{
    public int gunDamage = 1;
    public float fireRate = .25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public GameObject shotcollision;
    public Transform gunEnd;
    public AudioClip shotSound;

    //private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.05f);
    //private AudioSource gunAudio;
    private rotation2 direction;
    private LineRenderer laserLine;
    private float nextFire;


    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        direction = GetComponent<rotation2>();
        //gunAudio = GetComponent<AudioSource>();
        //fpsCam = GetComponent<Camera>();
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            laserLine.SetPosition(0, gunEnd.position);
            Instantiate(shotcollision, gunEnd.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(shotSound, transform.position, 1f);
            RaycastHit2D hit = Physics2D.Raycast(gunEnd.position, direction.Dist, weaponRange);
            if (hit.collider != null)
            {
                laserLine.SetPosition(1, hit.point);
                Instantiate(shotcollision, hit.point, Quaternion.identity);
               // Destroy(shotss, 0.1f) ;
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
                laserLine.SetPosition(1, direction.Dist);
            }
        }
    }

    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}
