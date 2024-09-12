using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveC : MonoBehaviour
{
    [SerializeField] Transform player;

    private void FixedUpdate()
    {
        this.transform.position = player.transform.position;
    }
}
