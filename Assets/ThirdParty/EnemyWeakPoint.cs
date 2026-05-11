using UnityEngine;

public class EnemyWeakPoint : MonoBehaviour
{
    [Header("연결된 적")]
    public EnemyController enemy;

    [Header("약점 설정")]
    public bool instantKill = true;
    public int damage = 999;

    private void Awake()
    {
        // 자동 연결 (자식이면 부모에서 찾기)
        if (enemy == null)
        {
            enemy = GetComponentInParent<EnemyController>();
        }
    }

    public void Hit()
    {
        if (enemy == null) return;

        if (instantKill)
        {
            enemy.TakeDamage(enemy.health); // 즉사
        }
        else
        {
            enemy.TakeDamage(damage);
        }
    }
}