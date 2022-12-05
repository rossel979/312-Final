using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;

    public Vector3 upRecoil;
    Vector3 originalRotation;
    
    void Start()
    {
        originalRotation = transform.localEulerAngles;
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }


        if (Input.GetButtonDown("Fire1"))
            AddRecoil();
        else if (Input.GetButtonUp("Fire1"))
                StopRecoil();
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();

    }
    private void PlayMuzzleFlash() 
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private  void CreateHitImpact(RaycastHit hit)
    {
        //destroys effect and makes it shoot out away from the camera when it hits
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }

    private void AddRecoil() 
    {
        transform.localEulerAngles += upRecoil;
    }

    private void StopRecoil() 
    {
        transform.localEulerAngles = originalRotation;
    }
}
