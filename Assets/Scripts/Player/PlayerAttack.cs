using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack Instance { get; private set; }
    void Awake() => Instance = this;

    private SkillElements skill;
    public List<int> skillValue = new List<int> { 0 };
    SkillManager skillManager;
    [SerializeField] Transform player;
    private Vector2 mouseLocation;
    public bool isAttacking;
    private float playerMouseAngle;
    [SerializeField] PlayerDamage basicAttack;
    [SerializeField] GameObject basicAttackObject;
    public bool animate;

    public void Setup(SkillList _skill)
    {
        SkillCardRotation.Instance.isRotating = true;
        StartCoroutine(SETUP(_skill));
    }

    private IEnumerator SETUP(SkillList _skill)
    {
        yield return new WaitForSeconds(SkillCardRotation.Instance.rotationInterval);
        skill = _skill.skill[skillValue[0]];
    }

    private void Start()
    {
        skillManager = SkillManager.Instance;
        skill = null;
        basicAttack.damage = PlayerController.damage;
    }

    private void Update()
    {
        mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKey(KeySettings.skillAttackKey) && skill != null)
        {
            SkillAttack();
        }

        if (Input.GetKey(KeySettings.basicAttackKey) && !isAttacking)
        {
            StartCoroutine(BasicAttack());
        }
    }

    public IEnumerator BasicAttack()
    {
        isAttacking = true;
        animate = true;
        basicAttackObject.SetActive(true);
        Debug.Log(PlayerController.player.attackSpeed);
        yield return new WaitForSeconds(PlayerController.player.attackSpeed);
        basicAttackObject.SetActive(false);
        yield return new WaitForSeconds(PlayerController.player.attackCooldown);
        isAttacking = false;
    }

    public void SkillAttack()
    {
        if (skill.damage.self)
        {
            DoDamage.toTarget(PlayerController.player, skill.damage);
            if (!PlayerController.player.isInvincible)
            {
                StartCoroutine(PlayerDefend.Invincible());
            }
        }
        else
        {
            playerMouseAngle = Mathf.Atan2(mouseLocation.y - player.position.y, mouseLocation.x - player.position.x) * Mathf.Rad2Deg + 90;
        }

        var skillObject = Instantiate(skill.damage.prefab, transform.position, Quaternion.Euler(0f, 0f, playerMouseAngle));
        for (int i = 0; i < skillObject.transform.childCount; i++)
        {
            skillObject.transform.GetChild(i).gameObject.GetComponent<PlayerDamage>().damage = skill.damage;
        }

        GameObject[] children = new GameObject[skillObject.transform.childCount];

        Destroy(skillObject, 3f);
        skill = null;
        StartCoroutine(SkillCardRotation.Instance.RotationCoroutine());
        SkillCardRotation.Instance.shouldRotate = true;
        skillManager.indicatorSprite.sprite = null;
    }
}
