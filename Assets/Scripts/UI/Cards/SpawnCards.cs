using System.Collections.Generic;
using UnityEngine;

public class SpawnCards
{
    public void GetSkills(SkillSO skills, List<SkillElements> cardList)
    {
        foreach (var card in skills.skills)
        {
            cardList.Add(card);
        }
    }

    public void Spawn(Transform cardRotation, GameObject cardPrefab, List<SkillElements> cardList, float cardDistance)
    {
        for (int j = 0; j < cardList.Count; j++)
        {
            float angle = (j == 0) ? Mathf.PI / 2 : (j * -Mathf.PI * 2 / cardList.Count) + Mathf.PI / 2;
            Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);

            float initialRotationAngle = 0f;

            Vector3 rotatedDirection = Quaternion.Euler(0, 0, initialRotationAngle) * direction;

            Vector3 cardPosition = cardRotation.position + rotatedDirection * cardDistance;

            var cardObject = Object.Instantiate(cardPrefab, cardPosition, Quaternion.identity);
            cardObject.transform.SetParent(cardRotation);
            cardObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, rotatedDirection);

            var cardElement = cardObject.GetComponent<CardElement>();
            cardElement.CardSprite.sprite = cardList[j].cardSprite;
        }
    }
}