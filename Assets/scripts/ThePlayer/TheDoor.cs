using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDoor : MonoBehaviour
{
    public float Health = 1000;
    public Animator animator = null;
    public AudioClip[] SoundOfHit = null;
    public AudioClip SoundOfCrashed = null;
    public AudioClip LoseSound = null;

    private Transform CameraPosition;

    private void Start()
    {
        CameraPosition = Camera.main.transform;
    }

    public void returnColor()
    {
        if (animator) animator.SetBool("hited", false);
    }

    public void GetDamge(float TheDamge)
    {
        Health -= TheDamge;
        if (SoundOfHit.Length > 0)
        {
            int randSound = (int)Random.Range(0, SoundOfHit.Length);
            AudioSource.PlayClipAtPoint(SoundOfHit[randSound], CameraPosition.position, 0.8f);
        }
        if (animator) animator.SetBool("hited", true);
        if (Health <= 0)
        {
            Crashed();
        }
    }

    private void Crashed()
    {
        if (SoundOfCrashed) AudioSource.PlayClipAtPoint(SoundOfCrashed, CameraPosition.position, 1f);
        //Destroy(gameObject);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        StartCoroutine(AfterCrashed());
    }

    private IEnumerator AfterCrashed()
    {
        yield return new WaitForSeconds(0.5f);
        if (LoseSound) AudioSource.PlayClipAtPoint(LoseSound, CameraPosition.position, 1f);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<ManageScenes>().MissionScene();
    }
}
