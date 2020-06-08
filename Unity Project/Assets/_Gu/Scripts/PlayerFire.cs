using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;    //총알 프리팹
    public GameObject firePoint;         //총알 위치

    public GameObject target;
    

    //레이져를 발사하기 위해서는 라인렌더러가 필요하다
    //선은 최소 2개의 점이 필요하다(시작점, 끝점)
    LineRenderer lr;    //라인렌더러 컴포넌트


    public float rayTime = 1.0f;       //스폰타임(생성주기)
    public float timer;                //누적타임


    // Start is called before the first frame update
    void Start()
    {
        //라인렌더러 컴포넌트 추가
        lr = GetComponent<LineRenderer>();
        //중요
        //게임오브젝트는 활성화 비활성화 => SetActive() 함수 사용
        //하지만 컴포넌트는 enabled 속성 사용

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.forward, Color.yellow);
        //Fire();
        FireRay();

        //레이저 보여주는 기능이 활성화 되어 있을때만
        //레이저를 보여준다.
        //일정시간이 지나면 레이져 보여주는 기능 비활성화
        if (lr.enabled) ShowRay();
    }

    private void ShowRay()
    {
        timer += Time.deltaTime;
        if(timer>rayTime)
        {
            lr.enabled = false;
            timer = 0.0f;
        }
    }

    //총알 발사
    public void Fire()
    {
        //마우스왼쪽 버튼 혹은 왼쪽컨트롤 키
        if (Input.GetButtonDown("Fire1"))
        {
            //총알공장(총알프리팹)에서 총알을 무한대로 찍어낼 수 있다.
            //Instantiate() 함수로 프리팹 파일을 게임오브젝트로 만든다.

            //총알 게임오브젝트 생성
            GameObject bullet = Instantiate(bulletFactory);
            //총알 오브젝트의 위치 지정
            bullet.transform.position = firePoint.transform.position;
        }
    }

    //레이져 발사
    public void FireRay()
    {

        //마우스왼쪽 버튼 혹은 왼쪽컨트롤 키
        if (Input.GetButton("Fire1"))
        {
            //라인렌더러 컴포넌트 활성화
            lr.enabled = true;
            //라인 시작점, 끝점
            lr.SetPosition(0, transform.position);
            //lr.SetPosition(1, transform.position + Vector3.up * 10);
            //라인의 끝점은 충돌된 지점으로 변경한다


            //Ray로 충돌처리
            Ray ray = new Ray(transform.position, Vector3.up);
            RaycastHit hitInfo;     //Ray와 충돌된 오브젝트의 정보를 담는다.
            //Ray랑 충돌된 오브젝트가 있다
            if (Physics.Raycast(ray, out hitInfo))
            {
                //레이저의 끝점 지정
                lr.SetPosition(1, hitInfo.point);

                //충돌된 오브젝트 삭제    

                ////디스트로이존의 탑과는 충돌처리 되지 않도록 한다.
                //if (hitInfo.collider.name != "Top")
                //{
                //    Destroy(hitInfo.collider.gameObject);
                //}

                //Contains("Enemy") => Enemy(clone) 이런것을 처리해주기위해 사용 (포함 이름을 찾아낸다)
                if (hitInfo.collider.name.Contains("Enemy"))
                {
                    Destroy(hitInfo.collider.gameObject);
                }


            }
            else
            {
                //충돌된 오브젝트가 없으니 끝점을 맨끝으로
                lr.SetPosition(1, transform.position + Vector3.up * 10);
            }

        }
    }

    public void OnFireButtonClick()
    {

        //총알 게임오브젝트 생성
        GameObject bullet = Instantiate(bulletFactory);
        //총알 오브젝트의 위치 지정
        bullet.transform.position = firePoint.transform.position;
    }
}
