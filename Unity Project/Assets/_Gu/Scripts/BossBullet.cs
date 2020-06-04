using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    //총알클래스 하는일
    //플레이어가 발사 버튼을 누르면
    //총알이 생성된 후 발사방향으로 움직인다.

    public GameObject target;

    public float speed = 10.0f;

    Vector3 dir;

    private void Start()
    {
        target = GameObject.FindWithTag("Player");


        dir = (target.transform.position - transform.position).normalized;
    }

    void Update()
    {

        transform.Translate(dir * speed * Time.deltaTime);
    }

    ////카메라 화면밖으로 나가서 보이지 않게 되면
    ////호출되는 이벤트 함수 
    ////**자주 사용하지 않음**
    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}
}
