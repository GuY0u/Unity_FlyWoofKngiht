using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;    //총알 프리팹
    public GameObject firePoint;         //총알 위치

    public float delay=0.1f;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SubFire());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        StartCoroutine(SubFire());
    }


    IEnumerator SubFire()
    {

        //총알 게임오브젝트 생성
        GameObject bullet = Instantiate(bulletFactory);
        //총알 오브젝트의 위치 지정
        bullet.transform.position = firePoint.transform.position;
        yield return new WaitForSeconds(delay);

        StartCoroutine(SubFire());
    }

    //private void Fire()
    //{
    //    //마우스왼쪽 버튼 혹은 왼쪽컨트롤 키

    //    //총알공장(총알프리팹)에서 총알을 무한대로 찍어낼 수 있다.
    //    //Instantiate() 함수로 프리팹 파일을 게임오브젝트로 만든다.



    //}
}