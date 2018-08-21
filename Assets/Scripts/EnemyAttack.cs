using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{

    //gör om gör rätt
    /*
    [SerializeField] bool attacking = false;
    //trigger collider sets range
    [SerializeField] bool inRange = false;

    [SerializeField] float attackSpeed = 1.0f;

    private void Update()
    {
        if (inRange && attacking == false)
        {
            attacking = true;
            StartCoroutine(Attack());
            print("attack start");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GetComponent<EnemyTargetSeeking>().myTarget)
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == GetComponent<EnemyTargetSeeking>().myTarget)
        {
            inRange = false;
            StopAllCoroutines();
            attacking = false;
        }
    }

    IEnumerator Attack()
    {

        yield return new WaitForSeconds(attackSpeed);
        //take damage here
        print("hit");
        attacking = false;
    }
    */
}
    