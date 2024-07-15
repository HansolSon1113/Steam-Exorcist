// //Not Complete!
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerAttack : MonoBehaviour
// {
//     [SerializeField] SkillSO skillSO;
//     private List<SkillElements> skillList = new List<SkillElements> { };
//     private int i = -1;
//     private Quaternion Q;
//     CardManager cardManager = CardManager.Instance;

//     public void Setup(int index)
//     {
//         StartCoroutine(SETUP(index));
//     }

//     private IEnumerator SETUP(int index)
//     {
//         yield return new WaitForSeconds(0.1f);
//         i = index;
//     }

//     private void Start()
//     {
//         foreach (var skill in skillSO.skills)
//         {
//             skillList.Add(skill);
//         }
//     }

//     private void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.F) && i != -1)
//         {

//         }
//     }

//     public void Attack()
//     {
//         if (skillList[i].ally)
//         {
//             Health.Inst.health -= skillList[i].damage;
//         }

//         if (Player.direction == 1 && !skillList[i].ally)
//         {
//             Q = Quaternion.Euler(0, 0, 180);
//         }
//         else
//         {
//             Q = Quaternion.Euler(0, 0, 0);
//         }

//         var skill = Instantiate(skillList[i].prefab, transform.position, Q);

//         GameObject[] children = new GameObject[skill.transform.childCount];

//         for (int i = 0; i < skill.transform.childCount; i++)
//         {
//             skill.transform.GetChild(i).gameObject.GetComponent<AddForce>().Setup(skillList[i].damage);
//         }

//         Destroy(skill, 3f);
//         i = -1;
//         cardManager.rotate();
//         cardManager.indicatorSprite.sprite = null;
//     }

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.gameObject.tag == "AISensor")
//         {
//             other.gameObject.GetComponent<AISensor>().Found();
//         }
//         if (other.gameObject.tag == "AISensor_Flying")
//         {
//             other.gameObject.GetComponent<AISensor_Flying>().Found();
//         }
//         if (other.gameObject.tag == "EnemyDamage")
//         {
//             Health.Inst.health -= 10;
//         }
//         if (other.gameObject.tag == "EnemyDamage_Range")
//         {
//             Health.Inst.health -= 10;
//             Destroy(other.gameObject);
//         }
//     }
// }
