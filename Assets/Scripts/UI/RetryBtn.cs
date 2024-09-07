using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RetryBtn : MonoBehaviour
{
    private TMP_Text text;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    private void OnMouseEnter()
    {
        this.transform.localScale = new Vector3(2f, 2f, 2f);
        text.text = "<i>Retry</i>";
    }

    private void OnMouseExit()
    {
        this.transform.localScale = new Vector3(1f, 1f, 1f);
        text.text = "Retry";
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
