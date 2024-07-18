//Not Complete!
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack Instance { get; private set; }
    void Awake() => Instance = this;
    
    private SkillElements skill;
    CardManager cardManager;
    [SerializeField] Transform player;
    public Damage damage;

    public void Setup(SkillElements _skill)
    {
        StartCoroutine(SETUP(_skill));
    }

    private IEnumerator SETUP(SkillElements _skill)
    {
        yield return new WaitForSeconds(0.1f);
        skill = _skill;
    }

    private void Start()
    {
        cardManager = CardManager.Instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && skill != null)
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (skill.damage.ally)
        {
            DoDamage.toTarget(Player.player, skill.damage);
        }
        else
        {
            damage = skill.damage;
        }

        var skillObject = Instantiate(skill.prefab, transform.position, Quaternion.Euler(0f, 0f, 90 * Player.direction));

        GameObject[] children = new GameObject[skillObject.transform.childCount];

        Destroy(skillObject, 3f);
        cardManager.Rotate();
        cardManager.indicatorSprite.sprite = null;
        skill = null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AISensor")
        {
            other.gameObject.GetComponent<EnemyController>().playerFound = true;
        }
        if (other.gameObject.tag == "AISensor_Flying")
        {
            other.gameObject.GetComponent<EnemyController>().playerFound = true;
        }
    }
}
