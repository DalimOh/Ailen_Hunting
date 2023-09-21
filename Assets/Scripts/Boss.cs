using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float fhealth = 100f;
    public GameObject gObj_missilePrefab;
    public Transform MissileSpawnpoint;
    public float fpattern1Cooldown = 10f;
    public float fpattern2Cooldown = 2f;
    private float fnextPattern1Time = 0f;
    private float fnextPattern2Time = 0f;

    private void Update()
    {
        if (Time.time > fnextPattern1Time)
        {
            Pattern1();
            fnextPattern1Time = Time.time + fpattern1Cooldown;
        }
        if (Time.time > fnextPattern2Time)
        {
            Pattern2();
            fnextPattern2Time = Time.time + fpattern2Cooldown;
        }



    }
    // Start is called before the first frame update
    private void Pattern1()
    {
        int inumberOfMissiles = 10; 
        float fangleStep = 360f;
        for (int i = 0; i < inumberOfMissiles; i++)
        {
            float fangle = i * fangleStep;
            Quaternion rotation = Quaternion.Euler(0f, 0f, fangle);
            Instantiate(gObj_missilePrefab, MissileSpawnpoint.position, rotation);
        }
    }
    private void Pattern2()
    {
        Vector3 direction = (new Vector3(FindPlayer().x, FindPlayer().y, transform.position.z) - transform.position).normalized;

        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
        for (int i = 0; i < 3; i++)
        {
            Instantiate(gObj_missilePrefab, MissileSpawnpoint.position, rotation);
        }
    }


    private Vector2 FindPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player").transform.position;
    }
    public void Takedamage(float damage)
    {
        fhealth -= damage;
        if (fhealth <= 0)
        {
            //  보스 죽었을때 로직 추가 
        }
    }
}