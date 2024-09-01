using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ExitBtn : MonoBehaviour
{
    private void OnMouseEnter()
    {
        this.transform.localScale = new Vector3(2f, 2f, 2f);
    }

    private void OnMouseExit()
    {
        this.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("Lobby");
    }
}
