using UnityEngine;
using System.Collections;
using System;

public class MovementController : MonoBehaviour, CameraController
{
    public float horSpeed = 5f;
    public float vertSpeed = 5f;
    public Transform playerTransform;
    public Rigidbody2D player;
    [SerializeField] Transform cameraArm;
    [SerializeField] float gravityAmount = 1f;
    public float h, v;
    public float cameraSpeed = 1f;
    private bool highJump = false;
    public bool cameraAttached;
    private Action cameraUpdateFunction;
    private Vector3 cameraVelocity = Vector3.zero;
    [SerializeField] Vector3 cameraOffset = new Vector3(0, 1, -10);
    [SerializeField] float aheadDistance = 2f;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        PlayerController.movementController = this;
        cameraUpdateFunction = cameraAttached ? UpdateCameraAttached : UpdateCameraUnAttached;
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxisRaw("Jump");

        if (h != 0)
        {
            player.AddForce(new Vector2(h * horSpeed, 0), ForceMode2D.Impulse);
        }
        else
        {
            player.velocity = new Vector2(player.velocity.x * 0.1f, player.velocity.y);
        }

        if (player.velocity.x > horSpeed)
        {
            player.velocity = new Vector2(5, player.velocity.y);
        }
        else if (player.velocity.x < -horSpeed)
        {
            player.velocity = new Vector2(-5, player.velocity.y);
        }

        if (PlayerController.player.isFlying && !highJump)
        {
            player.AddForce(Vector3.down * gravityAmount);
        }
        else if (!PlayerController.player.isFlying && v == 1)
        {
            player.AddForce(Vector3.up * v * vertSpeed, ForceMode2D.Impulse);
            StartCoroutine(JumpHigher());
        }

        if (h < 0)
        {
            PlayerController.player.direction = dir.left;
        }
        else if (h > 0)
        {
            PlayerController.player.direction = dir.right;
        }

        UpdateCameraPosition();
    }

    private IEnumerator JumpHigher()
    {
        highJump = true;
        PlayerController.player.isFlying = true;
        yield return new WaitForSeconds(0.5f);
        if (v != 1 || player.velocity.y <= 0)
        {
            highJump = false;
        }
    }

    public void UpdateCameraPosition()
    {
        cameraUpdateFunction();
    }

    private void UpdateCameraUnAttached()
    {
        float speedFactor = Mathf.Abs(player.velocity.x) / horSpeed;
        float dynamicAheadDistance = aheadDistance * speedFactor;
        Vector3 aheadOffset = new Vector3(dynamicAheadDistance * PlayerController.player.direction, 0, 0);
        Vector3 targetPosition = playerTransform.position + cameraOffset + aheadOffset;
        targetPosition.y += 1;
        Vector3 smoothedPosition = Vector3.SmoothDamp(cameraArm.position, targetPosition, ref cameraVelocity, 0.3f);
        cameraArm.position = smoothedPosition;
    }
    private void UpdateCameraAttached()
    {
        cameraArm.position = playerTransform.position + cameraOffset;
    }
}
