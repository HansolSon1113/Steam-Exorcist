using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject exitBtn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = settingPanel.activeSelf ? 1 : 0;
            settingPanel.SetActive(!settingPanel.activeSelf);
            exitBtn.SetActive(!exitBtn.activeSelf);
        }
    }
}
