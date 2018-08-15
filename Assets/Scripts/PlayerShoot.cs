using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public PlayerWeapon weapon;

    [SerializeField] EnemyManager enemyManager;

    [SerializeField] Camera cam;

    [SerializeField] LayerMask mask;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask))
        {
            //we hit something
            if(hit.collider.tag == "Enemy")
            {
                enemyManager.EnemyShot(hit.collider.gameObject, weapon.damage);
            }
        }
    }
    
}
