using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    [SerializeField] GameObject heartPrefab;
    [SerializeField] GameObject heartBackground;
    [SerializeField] GameObject barrierPrefab;
    public List<GameObject> hearts = new List<GameObject>();
    public List<GameObject> heartsBackground = new List<GameObject>();
    public List<GameObject> barriers = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < PlayerController.player.health.barrier; i++)
        {
            GameObject barrier = Instantiate(barrierPrefab, new Vector3(transform.position.x - 1.2f * i, transform.position.y, transform.position.z), Quaternion.identity);
            barriers.Add(barrier);
            barrier.transform.SetParent(this.transform);
        }

        for (int i = 0; i < PlayerController.player.health.maxHealth; i++)
        {
            GameObject heart = Instantiate(heartBackground, new Vector3(transform.position.x - 1.2f * (i + PlayerController.player.health.barrier), transform.position.y, transform.position.z), Quaternion.identity);
            heartsBackground.Add(heart);
            heart.transform.SetParent(this.transform);
        }

        for (int i = 0; i < PlayerController.player.health.health; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartsBackground[i].transform.position, Quaternion.identity);
            hearts.Add(heart);
            heart.transform.SetParent(this.transform);
        }
    }

    private void FixedUpdate()
    {
        if (PlayerController.player.health.health < hearts.Count)
        {
            Destroy(hearts[hearts.Count - 1]);
            hearts.RemoveAt(hearts.Count - 1);
        }

        if (PlayerController.player.health.health > hearts.Count)
        {
            GameObject heart = Instantiate(heartPrefab, new Vector3(transform.position.x - 1.2f * hearts.Count, transform.position.y, transform.position.z), Quaternion.identity);
            hearts.Add(heart);
            heart.transform.SetParent(this.transform);
        }

        if (PlayerController.player.health.barrier < barriers.Count)
        {
            Destroy(barriers[barriers.Count - 1]);
            barriers.RemoveAt(barriers.Count - 1);
            for (int i = 0; i < hearts.Count; i++)
            {
                heartsBackground[i].transform.position = new Vector3(transform.position.x - 1.2f * (i + PlayerController.player.health.barrier), transform.position.y, transform.position.z);
                hearts[i].transform.position = new Vector3(transform.position.x - 1.2f * (i + PlayerController.player.health.barrier), transform.position.y, transform.position.z);
            }
        }

        if (PlayerController.player.health.barrier > barriers.Count)
        {
            GameObject barrier = Instantiate(barrierPrefab, new Vector3(transform.position.x - 1.2f * (hearts.Count + barriers.Count), transform.position.y, transform.position.z), Quaternion.identity);
            barriers.Add(barrier);
            barrier.transform.SetParent(this.transform);
            for (int i = 0; i < hearts.Count; i++)
            {
                heartsBackground[i].transform.position = new Vector3(transform.position.x - 1.2f * (i + PlayerController.player.health.barrier), transform.position.y, transform.position.z);
                hearts[i].transform.position = new Vector3(transform.position.x - 1.2f * (i + PlayerController.player.health.barrier), transform.position.y, transform.position.z);
            }
        }
    }
}
