using System.Collections;
using UnityEngine;

public class SkillCardRotation : MonoBehaviour
{
    public static SkillCardRotation Instance { get; private set; }
    void Awake() => Instance = this;

    public float rotationSpeed = 30f;  // 1/12 ����(30��)�� ȸ���ϴ� �� �ɸ��� �ð� (�ʴ� ȸ�� ����)
    public float rotationInterval = 0.5f;  // 0.5�ʸ��� ȸ��

    private float targetAngle;
    private float currentAngle;
    public bool isRotating = false;
    public bool shouldRotate = true;
    // public Coroutine rotationCoroutineInstance = null;

    public void Setup()
    {
        // �ʱ� �� ����
        currentAngle = transform.eulerAngles.z;
        targetAngle = currentAngle + 30f; // 1/12 ���� (30��)
        StartCoroutine(RotationCoroutine());
    }

    public IEnumerator RotationCoroutine()
    {
        yield return new WaitForSeconds(rotationInterval);
        if (shouldRotate)
        {
            yield return StartCoroutine(RotateSprite());
        }

        SkillManager.Instance.i = (SkillManager.Instance.i + 1) % SkillManager.Instance.skillList.Count;
    }

    private IEnumerator RotateSprite()
    {
        isRotating = true;
        for (int i = 0; i < 3; i++)
        {
            targetAngle = currentAngle + 30f; // 1/12 ����(30��)

            // ȸ�� ����
            while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, targetAngle)) > 0.01f)
            {
                currentAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, currentAngle);
                yield return null;
            }

            currentAngle = targetAngle;
            if (i < 2)
            {
                yield return new WaitForSeconds(rotationInterval);
            }
        }
        isRotating = false;
        StartCoroutine(RotationCoroutine());
    }
}