using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("적 설정")]
    public float moveSpeed = 3f;
    public int health = 3;
    private Transform player;
    public GameObject explosionParticle;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null) return;

        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;

        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        
    }

    public void TakeDamage(int damage)
    {
        

        health -= damage;

        // 2. 트리거 직전에 로그 찍기
        Debug.Log("HitEnemy 트리거를 발동합니다.");
        anim.SetTrigger("HitEnemy");

        if (health <= 0)
        {
            GameManager.Instance?.AddKillScore();

            if (explosionParticle != null) 
            {
                Instantiate(explosionParticle, transform.position, Quaternion.identity);
            }

            AudioManager.Instance?.PlayExplosion();
       
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        Debug.Log("충돌");
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance?.AddDamageScore();

            Debug.Log("충돌2");
            Animator playerAnim = other.gameObject.GetComponent<Animator>();
            if ((playerAnim != null))
            {
                playerAnim.SetTrigger("playerDam");
            }
        }


    }



}
