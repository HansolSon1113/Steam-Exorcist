using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack Instance { get; private set; }
    void Awake() => Instance = this;

    private SkillElements skill;
    public List<int> skillValue = new List<int> { 0 };
    CardManager cardManager;
    [SerializeField] Transform player;
    private Vector2 mouseLocation;
    private bool isAttacking;
    private float playerMouseAngle;

    public void Setup(SkillList _skill)
    {
        StartCoroutine(SETUP(_skill));
    }

    private IEnumerator SETUP(SkillList _skill)
    {
        yield return new WaitForSeconds(0.1f);
        skill = _skill.skill[skillValue[0]];
    }

    private void Start()
    {
        cardManager = CardManager.Instance;
    }

    private void Update()
    {
        mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.F) && skill != null)
        {
            SkillAttack();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && !isAttacking)
        {
            StartCoroutine(BasicAttack());
        }
    }

    public IEnumerator BasicAttack()
    {
        isAttacking = true;
        playerMouseAngle = Mathf.Atan2(mouseLocation.y - player.position.y, mouseLocation.x - player.position.x) * Mathf.Rad2Deg + 90;
        var basicObject = Instantiate(PlayerController.damage.prefab, transform.position, Quaternion.Euler(0f, 0f, playerMouseAngle));
        for (int i = 0; i < basicObject.transform.childCount; i++)
        {
            basicObject.transform.GetChild(i).gameObject.GetComponent<Projectile_Example>().Setup(PlayerController.damage);
        }
        Destroy(basicObject, 1f);
        yield return new WaitForSeconds(PlayerController.player.attackSpeed);
        isAttacking = false;
    }

    public void SkillAttack()
    {
        if (skill.damage.self)
        {
            DoDamage.toTarget(PlayerController.player, skill.damage);
            if (!PlayerController.player.isInvincible)
            {
                StartCoroutine(PlayerController.Invincible());
            }
        }
        else
        {
            playerMouseAngle = Mathf.Atan2(mouseLocation.y - player.position.y, mouseLocation.x - player.position.x) * Mathf.Rad2Deg + 90;
        }

        var skillObject = Instantiate(skill.damage.prefab, transform.position, Quaternion.Euler(0f, 0f, playerMouseAngle));
        for (int i = 0; i < skillObject.transform.childCount; i++)
        {
            skillObject.transform.GetChild(i).gameObject.GetComponent<Projectile_Example>().Setup(skill.damage);
        }

        GameObject[] children = new GameObject[skillObject.transform.childCount];

        Destroy(skillObject, 3f);
        cardManager.Rotate();
        cardManager.indicatorSprite.sprite = null;
        skill = null;
    }
}
