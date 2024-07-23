using System.Collections.Generic;
using UnityEngine;

public interface CardSpawn
{
    public void GetSkills(SkillSO skills, List<SkillList> cardList);
    public void Spawn(Transform cardRotation, GameObject cardPrefab, List<SkillList> cardList, float cardDistance);
}

public class SpawnCards : MonoBehaviour, CardSpawn
{
    CardManager cardManager;

    public void GetSkills(SkillSO Skills, List<SkillList> cardList)
    {
        foreach (var card in Skills.skills)
        {
            cardList.Add(card);
        }
    }

    public void Spawn(Transform cardRotation, GameObject cardPrefab, List<SkillList> cardList, float cardDistance)
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            float angle = (i == 0) ? Mathf.PI / 2 : (i * -Mathf.PI * 2 / cardList.Count) + Mathf.PI / 2;
            Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);

            float initialRotationAngle = 0f;

            Vector3 rotatedDirection = Quaternion.Euler(0, 0, initialRotationAngle) * direction;

            Vector3 cardPosition = cardRotation.position + rotatedDirection * cardDistance;

            var cardObject = Object.Instantiate(cardPrefab, cardPosition, Quaternion.identity);
            cardObject.transform.SetParent(cardRotation);
            cardObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, rotatedDirection);

            var cardElement = cardObject.GetComponent<CardElement>();
            cardElement.Setup(cardList[i]);
        }
    }

    void Start()
    {
        cardManager = CardManager.Instance;
        GetSkills(cardManager.skillSO, cardManager.skillList);
        Spawn(cardManager.cardRotation, cardManager.cardPrefab, cardManager.skillList, cardManager.cardDistance);
        cardManager.Setup();
    }
}
