//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //애너미매니저의 역할?
    //애너미들을 공장에서 찍어낸다(애너미 프리팹)

    //필요한 것
    //애너미 스폰타임
    //애너미 스폰위치

    public GameObject enemyFactory;     //애너미 공장(애너미프리팹)
    //public GameObject spawnPoint;       //스폰위치
    public GameObject[] spawnPoint;
    public float spawnTime = 1.0f;       //스폰타임(생성주기)
    public float curTime;                //누적타임


    void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        //몇초에 한번씩 이벤트 발동
        //시간 누적타임으로 계산한다
        //게임에서 정말 자주 사용!

        curTime += Time.deltaTime;
        if (curTime > spawnTime)
        {
            //누적된 현재시간을 0초로 초기화(안하면 curTime의 숫자가 계속 누적됨)
            curTime = 0.0f;

            //스폰타임 랜덤
            spawnTime = Random.Range(0.5f, 2.0f);

            //애너미 생성
            GameObject enemy = Instantiate(enemyFactory);
            //enemy.transform.position = spawnPoint.transform.position;
            int index = Random.Range(0, spawnPoint.Length);
            enemy.transform.position = transform.GetChild(index).position;
            //enemy.transform.position = spawnPoint[index].transform.position;

        }
    }
}
