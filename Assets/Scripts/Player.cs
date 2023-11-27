using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] //(����ȭ�� ���� ����Ƽ �ν����Ϳ��� �� ��������)
    private GameObject gObj_Cam;
    private Rigidbody2D rb2D_player;
    private SpriteRenderer spr_player;
    private Animator anim_player;

    // Start is called before the first frame update
    void Start()
    {
        rb2D_player = GetComponent<Rigidbody2D>();
        spr_player = GetComponent<SpriteRenderer>();
        anim_player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (���ӸŴ������� ������ ���۵� ���°� �ƴҶ�) return;
        
        gObj_Cam.transform.position = transform.position - new Vector3(0f, 0f, 10f);
    }

    // test move function
    void FixedUpdate()
    {
        //if (���ӸŴ������� ������ ���۵� ���°� �ƴҶ�) return;

        float horSpeed = Input.GetAxis("Horizontal") * 5;
        float verSpeed = Input.GetAxis("Vertical") * 5;

        rb2D_player.velocity = new Vector2(horSpeed, verSpeed);
    }

    void LateUpdate()
    {
        //if (���ӸŴ������� ������ ���۵� ���°� �ƴҶ�) return;
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        //if (���ӸŴ������� ������ ���۵� ���°� �ƴҶ�) return;

        GameManager.gm_instance.f_health -= Time.deltaTime * 10;

        //ü���� �� �������� �� ����(���� ����X)
        /*if(GameManager.gm_instance.f_health < 0)
        {
            //transform�� �ڽ� ������Ʈ���� ������(���� 13 ����)
            for (int index=2; index < transform.childCount; index++)
            {
                transform.GetChild(index).gameObject.SetActive(false);
            }

            //anim_player.SetTrigger("Dead"); �״� �ִϸ��̼� ����, ������� �ּ�ó��
        }*/
    }
    
    //������̶� �ּ�ó���ص� �ڵ�
    /*colliding logics �浹 ����
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
            return;
        health -= collision.GetComponent<Enemy>().damage;
        if (health > 0)
        {
            //idle, hit motion
        }
        else
        {
            //died
            Dead();
        }
    }

    void Dead()
    {

    }*/
}
