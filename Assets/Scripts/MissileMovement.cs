using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MissileMovement : MonoBehaviour
{
    public float fspeed = 5f; 

    private Rigidbody2D rb2d;
    private Camera mainCamera;
    public float fdagameAmount = 10f; //�̻����� ���̹�
    public GameObject gObj_explosionPrefab; //�̻��� ���߽� ������ ������Ʈ (��������)

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }
    /* �÷��̾� �߰��Ŀ� �ּ�����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Plyaer>();
            if(player != null)
            {
                player.TakeDamage(damageAmount); // paly ��ũ��Ʈ�� ������ ���� �Լ� Ȯ���ϰ� ���� �ؾ���. 
            }
            //�̻��� ���� ȿ�� ����
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
        //�̻����� ��ġ�� ����Ʈ ��ǥ�ι�ȯ
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        // ����Ʈ ��ǥ�� 0�̸��̰ų� 1�ʰ��� ��� �̻����ı�
        if (viewPos.x < 0f || viewPos.x > 1f || viewPos.y < 0f || viewPos.y > 1f)
        {
            Destroy(gameObject);
        }
    }
}