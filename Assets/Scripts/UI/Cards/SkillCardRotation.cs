using System.Collections;
using UnityEngine;

public class SkillCardRotation : MonoBehaviour
{
    public float rotationSpeed = 30f;  // 1/12 ����(30��)�� ȸ���ϴ� �� �ɸ��� �ð� (�ʴ� ȸ�� ����)
    public float rotationInterval = 0.5f;  // 0.5�ʸ��� ȸ��

    private float targetAngle;
    private float currentAngle;

    void Start()
    {
        // �ʱ� �� ����
        currentAngle = transform.eulerAngles.z;
        targetAngle = currentAngle + 30f; // 1/12 ���� (30��)
        StartCoroutine(RotateSprite());
    }

    private IEnumerator RotateSprite()
    {
        while (true)
        {
            yield return new WaitForSeconds(rotationInterval);
            targetAngle = currentAngle + 30f; // 1/12 ����(30��)

            // ȸ�� ����
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
