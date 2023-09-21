using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float fSpeed;
    public float fHealth;
    public float fMaxHealth;
    public RuntimeAnimatorController[] animCon; 
    public Rigidbody2D target; //���Ͱ� �Ѿư� ��ǥ ����
    public GameObject gObj_player; // ���Ͱ� �Ѿư� ���ӿ�����Ʈ

    bool bIsLive;//

    Rigidbody2D rigid;
    Collider2D coll;
    Animator anim;
    SpriteRenderer spriter;
    WaitForFixedUpdate wait; //�����̸� ������ ����� ���ϰ� ����

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
        wait = new WaitForFixedUpdate();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!bIsLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))//��������ʰų� ���ݹ޴� �ִϸ��̼��� ���
            return;

        Vector2 v2_dirVec = target.position - rigid.position;  //Ÿ�� ��ġ - ���� ��ġ
        Vector2 v2_nextVec = v2_dirVec.normalized * fSpeed * Time.fixedDeltaTime; //�����ӿ� ���� ���̳��� �ʵ��� ��
        rigid.MovePosition(rigid.position + v2_nextVec); //������ġ+������ ���� �� ��ġ
        rigid.velocity = Vector2.zero; // �����ӵ��� �̵��� ������� �ʵ��� 0�� �־���
    }
    void LateUpdate()
    {
        if (!bIsLive) //������� �ʴٸ�
            return; //�ǵ����� �װ� �ƴ϶��

        spriter.flipX = target.position.x < rigid.position.x; //�̹��� ���� ����
    }
    void OnEnable()//��ũ��Ʈ�� Ȱ��ȭ�� �� �����ϴ� �Լ�
    {
        target = gObj_player.GetComponent<Rigidbody2D>(); //Ÿ�� ����
        bIsLive = true; //Ȱ��ȭ �� �� ���̺갡 Ʈ�� ��

        coll.enabled = true;
        rigid.simulated = true;
        spriter.sortingOrder = 2; //�ٽ� ���̾� ���� �������
        anim.SetBool("Dead", false);
        fHealth = fMaxHealth; //ü�� �ʱ�ȭ
    }

    /*
    public void Init(SpawnData data) //���Ͱ� �� �� ��ũ��Ʈ�� ����� ����
    {
        anim.runtimeAnimatorController = animCon[data.spriteType]; //�̹���
        fspeed = data.speed; //�ӵ�
        fmaxHealth = data.health; //�ִ�ü��
        fhealth = data.health; //ü��
    }*/

    void OnTriggerEnter2D(Collider2D collision)// ���ݹ��⿡ �浹���� ��
    {
        if (!collision.CompareTag("Bullet") || !bIsLive) // ���Ⱑ �ƴϰų� ��������� (����� ��ø���� ����)
            return;//

       // fhealth -= collision.GetComponent<Bullet>().damage;// ü���� �÷��̾� ���� ��ũ��Ʈ�� ������ ����
        StartCoroutine(KnockBack()); // �ǰ� �ڷ�ƾ Ȱ��ȭ

        if (fHealth > 0)//
        {
            anim.SetTrigger("Hit");//
        }
        else//
        {
            bIsLive = false;//���
            coll.enabled = false;//�浹 ����
            rigid.simulated = false;//���� ����
            spriter.sortingOrder = 1; //���������� ���� ����
            anim.SetBool("Dead", true);//��� �ִϸ��̼� Ȱ��
        }
    }
    IEnumerator KnockBack()// �ǰݽ� Ÿ�ݰ� �ڷ�ƾ
    {
        yield return wait; //���� �ϳ��� ���������ӱ��� ������. null���� ���̸� ���� 1������ ����. 
                           // yield return new WaitForSeconds(2f); //2�� ���� -> ���ϰ� ���� �ɸ��� ����
        Vector3 V2_playerPos = gObj_player.transform.position;
        Vector3 V2_dirVec = transform.position - V2_playerPos;
        rigid.AddForce(V2_dirVec.normalized * 3, ForceMode2D.Impulse);
    }
    void Dead()// ��� ��
    {
        gameObject.SetActive(false);
    }
}
