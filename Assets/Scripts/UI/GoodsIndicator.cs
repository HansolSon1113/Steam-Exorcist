using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoodsIndicator : MonoBehaviour
{
    [SerializeField] TMP_Text goodsText;

    private void FixedUpdate()
    {
        goodsText.text = GoodsManager.scraps.ToString();
    }
}
