using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class primStick : MonoBehaviour
{
    
    public float mouveSpeed = 10f;
    public Vector3 distanceFromTarget = Vector3.zero;
    public Animator animator = null;
    public float DamageSword = 100;

    private bool allowAttacking = false;
    private enemy isDead;
    private GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<enemy>().target) target = GetComponent<enemy>().target.gameObject;
        isDead = GetComponent<enemy>();
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            StopCoroutine(Attack());
            animator.SetBool("idel", true);
        }
        else
        {
            Bihavior();
        }
        

    }

    private void Bihavior()
    {
        Mouve();
        
    }

    private void Mouve()
    {
        Vector2 theActualPos = transform.position;
        Vector2 theNewPos = target.transform.position + distanceFromTarget;
        theNewPos = new Vector2(theNewPos.x, theActualPos.y);
        if (theActualPos.x == theNewPos.x && allowAttacking == false)
        {
            allowAttacking = true;
        }
        else if (allowAttacking == false && isDead.Died == false)
        {
           transform.position = Vector2.MoveTowards(theActualPos, theNewPos, mouveSpeed * Time.deltaTime);
            //transform.position += new Vector3(mouveSpeed * Time.deltaTime, 0f, 0f);
        }
        
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            if (allowAttacking == true)
            {
                animator.SetBool("idel", false);
                int randomAttack = Random.Range(1, 3);
                animator.SetInteger("attack", randomAttack);
                yield return new WaitForSeconds(3f);
                animator.SetBool("idel", true);
                yield return new WaitForSeconds(3f);
            }
            else
            {
                yield return new WaitForSeconds(1f);
            }
        }
    }

    private void AttackDamage()
    {
        target.GetComponent<TheDoor>().GetDamge(Random.Range(DamageSword/2, DamageSword));
    }
}
