using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectilePrefab; // 원거리 공격에 쓰이는 프리팹

    public List<int> skillValue = new List<int> { 0 };
    SkillManager skillManager;
    [SerializeField] Transform player;
    private Vector2 mouseLocation;
    private bool isAttacking;
    private float playerMouseAngle;

    public void UseSkill(SkillList skill)
    {
        switch (skill.name) //네 가지 스킬 목록
        {
            case "Judgement":
                StartCoroutine(Judgement());
                break;

            case "Hunting":
                StartCoroutine(Hunting());
                break;

            case "Blessing":
                Blessing();
                break;

            case "Overwhelming":
                StartCoroutine(Overwhelming());
                break;
        }
    }

    private IEnumerator Judgement()
    {
        // Judgement: 근접 범위딜
        Debug.Log("Judgement: 범위 근접 공격");
        yield return new WaitForSeconds(0.5f);
        // 스킬 구현
    }

    private IEnumerator Hunting()
    {
        // Hunting: 단발 원거리 공격
        Debug.Log("Hunting: 원거리 공격");
        //GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        //Destroy(projectile);
    }

    private void Blessing()
    {
        // Blessing: 플레이어 체력 회복
        Debug.Log("Blessing: 플레이어 체력 회복");
        //PlayerController.player.Heal(1f);
    }

    private IEnumerator Overwhelming()
    {
        // Overwhelming: 범위 공격
        Debug.Log("Overwhelming: 범위 공격");
        yield return new WaitForSeconds(0.5f);
    }
}
