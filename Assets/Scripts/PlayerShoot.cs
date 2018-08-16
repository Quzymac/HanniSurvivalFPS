using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public PlayerWeapon weapon;

    [SerializeField] GameObject enemyManager;

    [SerializeField] Camera cam;

    [SerializeField] LayerMask mask;

    [SerializeField] GameObject recoilComponent;

    private void Start()
    {
        enemyManager = GameObject.Find("EnemyManager");
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
        recoilComponent.GetComponent<Recoil>().StartRecoil(0.2f, -weapon.recoil, weapon.recoilSpeed);

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask))
        {
            //we hit something
            if(hit.collider.tag == "Enemy")
            {
                enemyManager.GetComponent<EnemyManager>().EnemyShot(hit.collider.gameObject, weapon.damage);
            }
        }
    }
    
}
