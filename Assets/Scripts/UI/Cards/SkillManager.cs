using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance { get; private set; }
    void Awake() => Instance = this;
    public SkillSO skillSO;
    [HideInInspector] public List<SkillList> skillList = new List<SkillList> { };
    [HideInInspector]public int i = 0;
    public float radius = 5f;
    public float cardDistance = 1.5f;
    public SpriteRenderer indicatorSprite;
    [SerializeField] GameObject player;
    PlayerAttack playerAttack;

    private void Start()
    {
        foreach (SkillList skill in skillSO.skills)
        {
            skillList.Add(skill);
        }

        playerAttack = player.GetComponent<PlayerAttack>();
        SkillCardRotation.Instance.Setup();
    }

    private void FixedUpdate()
    {
        if (skillList.Count != 0)
        {
            indicatorSprite.sprite = skillList[i].indicatorSprite;
        }

        if (Input.GetKey(KeySettings.skillAttackKey) && !SkillCardRotation.Instance.isRotating)
        {
            playerAttack.Setup(skillList[i]);
            SkillCardRotation.Instance.shouldRotate = false;
            // if (SkillCardRotation.Instance.rotationCoroutineInstance != null)
            // {
            //     //StopCoroutine(SkillCardRotation.Instance.rotationCoroutineInstance);
            //     SkillCardRotation.Instance.rotationCoroutineInstance = null;
            // }
        }

        // if (SkillCardRotation.Instance.shouldRotate && SkillCardRotation.Instance.rotationCoroutineInstance == null)
        // {
        //     SkillCardRotation.Instance.rotationCoroutineInstance = StartCoroutine(SkillCardRotation.Instance.RotationCoroutine());
        // }
    }
}
