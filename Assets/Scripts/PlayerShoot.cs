using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public PlayerWeapon weapon;

    GameObject enemyManager;

    [SerializeField] Camera cam;

    [SerializeField] LayerMask mask;
    
    [SerializeField] ParticleSystem flash1;
    [SerializeField] ParticleSystem flash2;

    float fireRateTimer;



    private void Start()
    {
        enemyManager = GameObject.Find("EnemyManager");
        fireRateTimer = weapon.fireRate;
    }


    private void Update()
    {
        fireRateTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && fireRateTimer <= 0)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        fireRateTimer = weapon.fireRate;
        cam.GetComponent<Recoil>().StartRecoil(weapon.recoil);
        
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
                //hit.collider.gameObject.GetComponent<Rigidbody>().AddForceAtPosition((hit.collider.transform.position - gameObject.transform.position).normalized * 0.8f, hit.point, ForceMode.Impulse);
            }
            if (hit.collider.tag == "Object")
            {
                //knocks objects away when hit
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForceAtPosition((hit.collider.transform.position - gameObject.transform.position).normalized, hit.point, ForceMode.Impulse);
            }
        }
    }
    
}
