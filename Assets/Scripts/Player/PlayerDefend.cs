using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefend : MonoBehaviour
{
    [SerializeField] GameObject shield;

    public static IEnumerator Invincible()
    {
        PlayerController.player.isInvincible = true;
        yield return new WaitForSeconds(PlayerController.player.invDuration);
        PlayerController.player.isInvincible = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeySettings.defendKey) && !PlayerController.player.isDefending)
        {
            StartCoroutine(Defend());
        }
    }

    private IEnumerator Defend()
    {
        PlayerController.player.isDefending = true;
        shield.SetActive(true);
        yield return new WaitForSeconds(PlayerController.player.defDuration);
        shield.SetActive(false);
        yield return new WaitForSeconds(5f);
        PlayerController.player.isDefending = false;
    }
}
