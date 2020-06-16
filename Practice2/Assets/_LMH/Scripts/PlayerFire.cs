using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject grenadebox;
    
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            //Ray ray = new Ray(firePos.transform.position, transform.forward);
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if(Physics.Raycast(ray,out hitInfo, distance))
            {
                Debug.DrawRay(firePos.transform.position, firePos.transform.forward, Color.blue,10f);
                //이곳에 이제 그 물체파악하고 이펙트 띄우시면 됩니다.
                if(hitInfo.transform.tag == "Enemy")
                {
                    //파티클(피조록조록)실행 후 그 에너미의 체력 깍기?
                }
            }

        }
        if(Input.GetMouseButtonDown(1))
        {
            GameObject grenade = Instantiate(grenadebox);
            grenade.transform.position = firePos.transform.position;
            grenade.transform.rotation = firePos.transform.rotation;

        }
    }
}
