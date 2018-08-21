using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour {

    float recoilTimer = 0.0f;
    float recoilPower = 10f;
    [SerializeField] Transform gun;

    Vector3 gunPosition;
    float gunRecoilAmountZ;


    void Start()
    {
        gunPosition = gun.localPosition;
        gunRecoilAmountZ = gunPosition.z - 0.3f;
    }


    void Update()
    {

        float recoilRotation = Random.Range(recoilPower * 0.3f, recoilPower) * 0.1f;
        
        //recoil up
        if (recoilTimer > 0.075f)
        {
            //camera up
            transform.Rotate(-recoilRotation, 0, 0);

            //gun back
            if (gun.localPosition.z > gunRecoilAmountZ)
            {
                gun.Translate(0, 0, -0.05f);
            }

            recoilTimer -= Time.deltaTime;
        }            
        //recoil down
        else if (recoilTimer > 0f)
        {
            //camera down
            transform.Rotate(recoilRotation * 0.33f, 0, 0);
            //gun forward
            gun.Translate(0, 0, 0.05f * 0.67f);
            
            recoilTimer -= Time.deltaTime * 0.33f;
        }
        else
        {
            //reset gun position
            gun.localPosition = Vector3.Lerp(gun.localPosition, gunPosition, Time.deltaTime * 10);

            recoilTimer = 0;
        }
    }
    public void StartRecoil(float recoilAmount)
    {
        recoilTimer = 0.2f;
        recoilPower = recoilAmount;
    }
}

