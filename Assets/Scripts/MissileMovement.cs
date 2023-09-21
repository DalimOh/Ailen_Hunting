using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MissileMovement : MonoBehaviour
{
    public float fspeed = 5f; 

    private Rigidbody2D rb2d;
    private Camera mainCamera;
    public float fdagameAmount = 10f; //미사일의 데이미
    public GameObject gObj_explosionPrefab; //미사일 폭발시 생성될 오브젝트 (만들어야함)

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }
    /* 플레이어 추가후에 주석제거
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Plyaer>();
            if(player != null)
            {
                player.TakeDamage(damageAmount); // paly 스크립트의 데미지 들어가는 함수 확인하고 변경 해야함. 
            }
            //미사일 폭발 효과 생성
            if(gObj_explosionPrefab)
            {
                Instantiate(gObj_explosionPrefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
    */
    private void Start()
    {
                               
        Vector2 moveDirection = transform.up;
        rb2d.velocity = moveDirection * fspeed;
    }

    private void Update()
    {
        //미사일의 위치를 뷰포트 좌표로반환
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        // 뷰포트 좌표가 0미만이거나 1초과인 경우 미사일파괴
        if (viewPos.x < 0f || viewPos.x > 1f || viewPos.y < 0f || viewPos.y > 1f)
        {
            Destroy(gameObject);
        }
    }
}