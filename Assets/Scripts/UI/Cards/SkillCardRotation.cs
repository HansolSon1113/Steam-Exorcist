using System.Collections;
using UnityEngine;

public class SkillCardRotation : MonoBehaviour
{
    public static SkillCardRotation Instance { get; private set; }
    void Awake() => Instance = this;

    public float rotationSpeed = 30f;
    public float rotationInterval = 0.5f;

    private float targetAngle;
    private float currentAngle;
    private float angleTolerance = 15f;
    public bool isRotating = false;
    public bool shouldRotate = true;

    // ���� �� �ִ� ����
    private readonly float[] canStopAngles = { 0f, 90f, 180f, 270f };

    public void Setup()
    {
        currentAngle = transform.eulerAngles.z;
        StartCoroutine(RotationCoroutine());
    }

    public IEnumerator RotationCoroutine()
    {
        while (shouldRotate)
        {
            yield return new WaitForSeconds(rotationInterval);
            yield return StartCoroutine(RotateSprite());
            SkillManager.Instance.i = (SkillManager.Instance.i + 1) % SkillManager.Instance.skillList.Count;
        }
    }

    private IEnumerator RotateSprite()
    {
        isRotating = true;

        targetAngle = currentAngle + 30f; // 30���� ȸ��

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, targetAngle)) > 0.01f)
        {
            currentAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, currentAngle);
            yield return null;
        }

        currentAngle = targetAngle;
        isRotating = false;
    }

    public bool CanStop()
    {
        // ���ߴ� ���� ����
        foreach (float angle in canStopAngles)
        {
            if (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, angle)) <= angleTolerance)
            {
                return true;
            }
        }
        return false;
    }

}
