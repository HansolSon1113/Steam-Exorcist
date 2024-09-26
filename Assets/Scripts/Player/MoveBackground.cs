using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private Vector3 orgPlayer = new Vector3(0, 0, 0);

    void Update()
    {
        this.transform.position += (orgPlayer - PlayerController.movementController.playerTransform.position) * 0.05f;
        orgPlayer = PlayerController.movementController.playerTransform.position;
    }
}