using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }
    void Awake() => Instance = this;
    public float rotationSec = 0.3f;
    public SkillSO skillSO;
    public GameObject cardPrefab;
    [HideInInspector] public List<SkillElements> skillList = new List<SkillElements> { };
    public Transform cardRotation;
    private bool isRotating = false;
    private int i = 0;
    public float radius = 5f;
    public float cardDistance = 1.5f;
    private bool shouldRotate = true;
    private Coroutine rotationCoroutineInstance;
    public SpriteRenderer indicatorSprite;
    [SerializeField] GameObject player;
    PlayerAttack playerAttack;

    public void Rotate()
    {
        shouldRotate = true;
        isRotating = true;
        if (rotationCoroutineInstance == null)
        {
            rotationCoroutineInstance = StartCoroutine(RotationCoroutine());
        }
    }

    private IEnumerator RotationCoroutine()
    {
        yield return new WaitForSeconds(1f);

        if (!shouldRotate)
        {
            yield break;
        }

        isRotating = true;
        yield return StartCoroutine(RotateCards(rotationSec));
        i = (i + 1) % skillList.Count;

        rotationCoroutineInstance = null;
    }

    private IEnumerator RotateCards(float duration)
    {
        float elapsedTime = 0f;
        float initialRotation = cardRotation.rotation.eulerAngles.z;
        float targetRotation = initialRotation + 360f / skillList.Count;

        while (elapsedTime < duration)
        {
            if (!shouldRotate)
            {
                yield break;
            }

            float newZ = Mathf.LerpAngle(initialRotation, targetRotation, elapsedTime / duration);
            cardRotation.rotation = Quaternion.Euler(0, 0, newZ);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cardRotation.rotation = Quaternion.Euler(0, 0, targetRotation);
        isRotating = false;
        yield return null;
    }

    public void Setup()
    {
        playerAttack = player.GetComponent<PlayerAttack>();
        if (skillList.Count != 0)
        {
            Rotate();
        }
    }

    private void Update()
    {
        if (skillList.Count != 0)
        {
            indicatorSprite.sprite = skillList[i].cardSprite;
        }

        if (Input.GetKeyDown(KeyCode.F) && !isRotating)
        {
            playerAttack.Setup(skillList[i]);
            shouldRotate = false;
            if (rotationCoroutineInstance != null)
            {
                StopCoroutine(rotationCoroutineInstance);
                rotationCoroutineInstance = null;
            }
        }

        if (shouldRotate && rotationCoroutineInstance == null)
        {
            rotationCoroutineInstance = StartCoroutine(RotationCoroutine());
        }
    }
}
