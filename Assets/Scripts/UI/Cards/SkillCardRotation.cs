using System.Collections;
using UnityEngine;

public class SkillCardRotation : MonoBehaviour
{
    public float rotationSpeed = 30f;  // 1/12 바퀴(30도)를 회전하는 데 걸리는 시간 (초당 회전 각도)
    public float rotationInterval = 0.5f;  // 0.5초마다 회전

    private float targetAngle;
    private float currentAngle;

    void Start()
    {
        // 초기 값 설정
        currentAngle = transform.eulerAngles.z;
        targetAngle = currentAngle + 30f; // 1/12 바퀴 (30도)
        StartCoroutine(RotateSprite());
    }

    private IEnumerator RotateSprite()
    {
        while (true)
        {
            yield return new WaitForSeconds(rotationInterval);
            targetAngle = currentAngle + 30f; // 1/12 바퀴(30도)

            // 회전 실행
            while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, targetAngle)) > 0.01f)
            {
                currentAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, currentAngle);
                yield return null;
            }

            currentAngle = targetAngle;
        }
    }
}
