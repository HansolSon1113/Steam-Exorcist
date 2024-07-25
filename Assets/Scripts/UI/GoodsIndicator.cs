using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsIndicator : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text goodsText;
    private void FixedUpdate()
    {
        goodsText.text = GoodsManager.scraps.ToString();
    }
}
