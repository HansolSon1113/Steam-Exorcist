using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    public GameObject heartPrefab;
    public List<GameObject> hearts = new List<GameObject>();

    private void Start()
    {
        Debug.Log(PlayerController.player.health.maxHealth);
        for (int i = 0; i < PlayerController.player.health.maxHealth; i++)
        {
            GameObject heart = Instantiate(heartPrefab, new Vector3(transform.position.x - 1.2f * i, transform.position.y, transform.position.z), Quaternion.identity);
            hearts.Add(heart);
            heart.transform.SetParent(this.transform);
        }
    }

    private void Update()
    {
        if(PlayerController.player.health.health < hearts.Count)
        {
            Destroy(hearts[hearts.Count - 1]);
            hearts.RemoveAt(hearts.Count - 1);
        }
    }
}
