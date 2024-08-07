using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class CSVRead : MonoBehaviour
{
    public int chatTable_col = 8;
    public TextAsset chat_Table;

    public static string[,] doubleChatList;

    void Start()
    {
        StartCoroutine(InputCsvArr());
    }

    IEnumerator InputCsvArr()
    {
        string[] chatList = chat_Table.text.Split(new char[] { '\n', ',' });
        int chatTable_row = chatList.Length / chatTable_col;
        doubleChatList = new string[chatTable_row, chatTable_col];

        int listChatNum = 0;

        for (int chatId = 0; chatId < chatTable_row; chatId++)
        {
            for (int chatTxt = 0; chatTxt < chatTable_col; chatTxt++)
            {
                doubleChatList[chatId, chatTxt] = chatList[listChatNum];
                listChatNum++;
            }
        }

        yield return null;

        Debug.Log(doubleChatList[0, 0]);
        Debug.Log(doubleChatList[2, 4]);
    }
}