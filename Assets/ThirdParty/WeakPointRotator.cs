using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPointRotator : MonoBehaviour
{
    [Header("대상 설정")]
    public Transform target;            // 추적할 적(Enemy)

    [Header("궤도 옵션")]
    public float radius = 1.5f;         // 원의 반지름
    public float rotationSpeed = 150f;  // 회전 속도

    [Header("높이 고정 설정")]
    [Tooltip("총알이 날아오는 고정 높이 (Y축)")]
    public float fixedWorldY = 0.8f;

    private float currentAngle = 0f;

    void Update()
    {
        if (target == null) return;

        // 1. 회전 각도 계산
        currentAngle += rotationSpeed * Time.deltaTime;
        float radian = currentAngle * Mathf.Deg2Rad;

        // 2. X, Z 평면 원운동 좌표 계산
        // 적의 현재 위치(target.position)를 기준으로 반지름만큼 떨어진 위치 계산
        float nextX = target.position.x + Mathf.Cos(radian) * radius;
        float nextZ = target.position.z + Mathf.Sin(radian) * radius;

        // 3. Y축(높이)은 적의 점프와 상관없이 0.8로 박제
        float nextY = fixedWorldY;

        // 4. 최종 위치 적용 (World Space)
        transform.position = new Vector3(nextX, nextY, nextZ);
    }

}
