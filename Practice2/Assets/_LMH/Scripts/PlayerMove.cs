using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    CharacterController cc; //chractercontroller

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h,0,v);       //ㄷㅐ각선 이동 속도를 상하좌우속도와 동일하게 만들기
        //게임에 따라 일부러 대각선은 빠르게 이동하도록 하는 경우도 있다.
        //이럴때는 벡터의 정규화를 하면 안된다.
        //dir.Normalize();
        dir = Camera.main.transform.TransformDirection(dir);
        transform.Translate(dir * speed * Time.deltaTime);

        cc.Move(dir * speed * Time.deltaTime);

    }
}
