﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //플레이어 이동
    public float speed = 5.0f; //플레이어 이동속도
    public Vector2 margin;

    //조이스틱 사용하기
    public VariableJoystick joystick;   //조이스틱

    public int lvl = 0;

    public GameObject[] subPlayer;

    Transform tr;

    public Transform field;


    // Start is called before the first frame update
    void Start()
    {
        //subPlayer.gameObject.SetActive(false);

        //subPlayer = new GameObject[2];

        tr = GetComponent<Transform>();
        field = GetComponent<Transform>();
        margin = new Vector2(0.05f, 0.08f);
    }

    // Update is called once per frame
    void Update()
    {
        //서브플레이어 부르기
        if (lvl == 1 || lvl == 2)
        {
            subPlayer[0].gameObject.SetActive(true);
        }
        else
        {
            subPlayer[0].gameObject.SetActive(false);
        }

        //서브플레이어 부르기
        if (lvl == 2)
        {
            subPlayer[1].gameObject.SetActive(true);
        }
        else
        {
            subPlayer[1].gameObject.SetActive(false);
        }

        //레벨 업
        if (Input.GetKeyDown(KeyCode.Q))
        {
            lvl--;
        }
        //레벨 다운
        if (Input.GetKeyDown(KeyCode.E))
        {
            lvl++;
        }

        Move();
    }

    private void Move()
    {


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //조이스틱 사용하기
        //키보드가 안눌렸을때 -> 조이스틱 사용하면 된다.
        if (h == 0 && v == 0)
        {
            h = joystick.Horizontal;
            v = joystick.Vertical;
        }


        if (tr.position.x > -24)
        {
            tr.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime, 0);
        }


        //Vector3 dir = Vector3.right * h + Vector3.up * v;

        //Vector3 dir = new Vector3(h, v, 0);

        //transform.Translate(dir * speed * Time.deltaTime);
        //transform.position = transform.position + (dir * speed*Time.deltaTime);
        //transform.position += dir * speed * Time.deltaTime;
        MoveInScreen();
    }

    private void MoveInScreen()
    {
        //방법은 크게 3가지
        //첫번째 : 화면밖의 공간에 큐브 4개 만들어서 배치
        //리지드바디의 충돌체로 이동 못하게 막기

        ////두번째 : 플레이어의 포지션으로 이동처리


        //transform.position의 값을 Vector3에 담아서 계산
        //다시 대입시키는 과정을 캐스팅이라고 한다.
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -2.5f, 2.5f);
        position.y = Mathf.Clamp(position.y, -3.5f, 3.5f);
        transform.position = position;

        //서브플레이어 이동 -필요없어짐
        //Vector3 subPosition = subPlayer.transform.position;
        //subPlayer.transform.position = transform.position;


        ////이러한 방식을 캐스팅이라고 한다.
        ////Vector3 position = transform.position;

        ////transform.position = position;

        //세번째 : 메인카메라의 뷰포트를 가져와서 처리한다(우리는 이것을 사용한다.)
        //스크린좌표 : 왼쪽하단(0, 0), 우측상단(maxX, maxY)
        //뷰표트좌표 : 왼쪽하단(0, 0), 우측상단(1.0f, 1.0f) ->뷰포트는 0~1사이 값으로 처리한다.
        //Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        //position.x = Mathf.Clamp(position.x, 0.0f + margin.x, 1.0f - margin.x);
        //position.y = Mathf.Clamp(position.y, 0.0f + margin.y, 1.0f - margin.y);
        //transform.position = Camera.main.WorldToViewportPoint(position);
    }
}
