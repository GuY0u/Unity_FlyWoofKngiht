using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{


    //위에서 아래로 떨어지기만 한다(똥피하기 느낌)
    //충돌처리(애너미랑 플레이어, 애너미랑 플레이어 총알)

    public float speed = 10.0f;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision coll)
    {

        //자기자신도 없애고
        //충돌된 오브젝트도 없앤다
        //Destroy(gameObject, 1.0f);

        //GameManager.instance.CountScore();
        ScoreManager.instance.AddScore();

        Destroy(gameObject);
        Destroy(coll.gameObject);
    }
}
