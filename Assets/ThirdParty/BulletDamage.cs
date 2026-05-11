using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [Header("총알 데미지")]
    public int damage = 1;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("WeakPoint"))
        {
            // 중요: 나(약점)에게 없으므로 '부모' 방향으로 올라가며 스크립트를 찾음
            EnemyController enemy = other.GetComponentInParent<EnemyController>();

            if (enemy != null)
            {
                Debug.Log("약점 명중! 부모의 체력을 깎습니다.");
                enemy.TakeDamage(enemy.health); // 즉사 로직
            }

            Destroy(gameObject); // 총알 삭제
            return;
        }

        else if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }

}
