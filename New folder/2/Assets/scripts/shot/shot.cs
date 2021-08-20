using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour {

	[SerializeField] GameObject theShot = null;
	[SerializeField] AudioClip shotsound = null;
	[Range(0f,1f)][SerializeField] float shotSoundVolume = 1f;
   

	[SerializeField] GameObject firstVectorPoint = null;
	[SerializeField] float speed = 5f;
	[SerializeField] float firePeriod = 0.2f;
    [SerializeField] GameObject theParentflept = null;

	Coroutine firecorotine;
    bool allowInvok = false;
    public bool allowShoting = true;
    


    private void Start()
    {
     
    }

    public void Fire(bool shot)
	{
		if (shot == true && allowShoting == true) {
			firecorotine = StartCoroutine (FireContinuously ());
            allowShoting = false;

        }
		if (shot == false) {
            StopCoroutine(firecorotine);
            if (allowInvok == false)
            {
                allowInvok = true;
                Invoke("RealodShot", firePeriod);
            }
		}
	}

    private void RealodShot()
    {
        allowInvok = false;
        allowShoting = true;
    }


    IEnumerator FireContinuously()
	{
		while (true)
        {
            float adjacent = transform.position.x - firstVectorPoint.transform.position.x;
            float opposite = transform.position.y - firstVectorPoint.transform.position.y;
            GameObject shots = Instantiate(theShot, transform.position, Quaternion.identity) as GameObject;
            Destroy(shots, 0.1f);
            //shots.GetComponent<Rigidbody2D>().velocity = new Vector2(adjacent * speed, opposite * speed);
            shots.layer = gameObject.layer;
            if (theParentflept.transform.localScale.x < 0)
            {
                shots.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            AudioSource.PlayClipAtPoint(shotsound, Camera.main.transform.position, shotSoundVolume);
            yield return new WaitForSeconds(firePeriod);
        }
            
	}
   
}
