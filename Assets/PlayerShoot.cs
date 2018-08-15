using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public PlayerWeapon weapon;

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
                EnemyShot(hit.collider.name);
            }
        }
    }
    //Move this to enemy manager
    void EnemyShot(string name)
    {
        Debug.Log(name + " has been shot!");
    }
}
