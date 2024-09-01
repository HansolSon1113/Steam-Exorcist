using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighlightOnMouseover : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }

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
        Time.timeScale = 1;
        SceneManager.LoadScene("Floor1");
    }
}
