using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm_instance = null;
    //Headers are userd for viewing property in Unity ����� ���� ������ ����Ƽ���� �� ������ ��������
    [Header("# Game Control")]
    public float f_gameTime;
    public float f_maxGameTime; //���� �����ּ��� ���� 10�� �����ɿ� -����
    [Header("# Player Info")]
    public float f_health; //health �÷��̾� ü��
    public float f_maxHealth = 100; //health �÷��̾� �ִ� ü��
    public int i_level; //level �÷��̾� ����
    public int i_kill; //kill ų ��
    public int i_exp; //exp ����ġ
    [Header("# Board Managing")]
    public BoardManager bm_boardScript;
    private int iLevel = 9;

    // Start is called before the first frame update
    void Awake()
    {
        if (gm_instance == null)
            gm_instance = this;
        else if (gm_instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        bm_boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    /*Public void GameStart() //Game start ���� ����
    {
        f_health = f_maxHealth; //health is set by max when it start �����Ҷ� ü���� �ִ�ü������ ������
    }*/

    void InitGame()
    {
        bm_boardScript.SetupScene(iLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
