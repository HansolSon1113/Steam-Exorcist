using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectilePrefab; // ���Ÿ� ���ݿ� ���̴� ������

    public List<int> skillValue = new List<int> { 0 };
    SkillManager skillManager;
    [SerializeField] Transform player;
    private Vector2 mouseLocation;
    private bool isAttacking;
    private float playerMouseAngle;

    public void UseSkill(SkillList skill)
    {
        switch (skill.name) //�� ���� ��ų ���
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
        // Judgement: ���� ������
        Debug.Log("Judgement: ���� ���� ����");
        yield return new WaitForSeconds(0.5f);
        // ��ų ����
    }

    private IEnumerator Hunting()
    {
        // Hunting: �ܹ� ���Ÿ� ����
        Debug.Log("Hunting: ���Ÿ� ����");
        //GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        //Destroy(projectile);
    }

    private void Blessing()
    {
        // Blessing: �÷��̾� ü�� ȸ��
        Debug.Log("Blessing: �÷��̾� ü�� ȸ��");
        //PlayerController.player.Heal(1f);
    }

    private IEnumerator Overwhelming()
    {
        // Overwhelming: ���� ����
        Debug.Log("Overwhelming: ���� ����");
        yield return new WaitForSeconds(0.5f);
    }
}
