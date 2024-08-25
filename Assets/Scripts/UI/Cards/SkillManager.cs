using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance { get; private set; }
    void Awake() => Instance = this;

    public SkillSO skillSO; // ScriptableObject를 통한 스킬 데이터 관리
    [HideInInspector] public List<SkillList> skillList = new List<SkillList>();
    [HideInInspector] public int i = 0; // 현재 선택된 스킬 인덱스
    public SpriteRenderer indicatorSprite;
    [SerializeField] GameObject player;
    PlayerAttack playerAttack;

    private bool skillActivated = false; // 스킬이 발동된 상태를 추적

    private void Start()
    {
        foreach (SkillList skill in skillSO.skills)
        {
            skillList.Add(skill);
        }

        playerAttack = player.GetComponent<PlayerAttack>();
        SkillCardRotation.Instance.Setup();
    }

    private void Update()
    {
        if (SkillCardRotation.Instance == null)
        {
            Debug.LogError("SkillCardRotation.Instance is null");
        }

        if (skillList == null || skillList.Count == 0)
        {
            Debug.LogError("Skill list is null or empty");
        }

        if (skillList.Count > 0 && skillList[i] == null)
        {
            Debug.LogError($"Skill at index {i} is null");
        }

        if (skillList.Count != 0)
        {
            indicatorSprite.sprite = skillList[i].indicatorSprite;
        }

        // F키 입력 처리
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (SkillCardRotation.Instance.isRotating)
            {
                // 회전 멈출 수 있는 상태인지 확인
                if (SkillCardRotation.Instance.CanStop())
                {
                    // 회전 멈추기
                    SkillCardRotation.Instance.shouldRotate = false;
                    SkillCardRotation.Instance.isRotating = false;
                    skillActivated = true;
                }
            }
            else if (skillActivated)
            {
                // 스킬 발동
                playerAttack.UseSkill(skillList[i]);

                // 스킬 후 회전 재개
                skillActivated = false;
                SkillCardRotation.Instance.shouldRotate = true;
                StartCoroutine(SkillCardRotation.Instance.RotationCoroutine());
            }
        }
    }
}
