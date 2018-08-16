using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public PlayerWeapon weapon;

    [SerializeField] GameObject enemyManager;

    [SerializeField] Camera cam;

    [SerializeField] LayerMask mask;

    [SerializeField] GameObject recoilComponent;

    [SerializeField] ParticleSystem flash1;
    [SerializeField] ParticleSystem flash2;



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
        flash1.Play();
        flash2.Play();

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask))
        {
            //we hit something
            if(hit.collider.tag == "Enemy")
            {
                enemyManager.GetComponent<EnemyManager>().EnemyShot(hit.collider.gameObject, weapon.damage);
                //knocks enemy back when hit
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForceAtPosition((hit.collider.transform.position - gameObject.transform.position).normalized * 0.8f, hit.point, ForceMode.Impulse);
            }
            if (hit.collider.tag == "Object")
            {
                //knocks objects away when hit
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForceAtPosition((hit.collider.transform.position - gameObject.transform.position).normalized, hit.point, ForceMode.Impulse);
            }
        }
    }
    
}
