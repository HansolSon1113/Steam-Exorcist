using UnityEngine;
using System.Collections;

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
    private Animator animator;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        PlayerController.movementController = this;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxisRaw("Jump");
        animator.SetBool("RunRight", false);
        animator.SetBool("RunLeft", false);
        animator.SetBool("isRun", false);

        if (h != 0)
        {
            player.AddForce(new Vector2(h * horSpeed, 0), ForceMode2D.Impulse);
        }
        else
        {
            player.velocity = new Vector2(player.velocity.x * 0.1f, player.velocity.y);
            animator.SetBool("RunRight", false);
            animator.SetBool("RunLeft", false);
            animator.SetBool("isRun", false);
        }

        if (player.velocity.x > horSpeed)
        {
            animator.SetBool("RunRight", true);
            animator.SetBool("RunLeft", false);
            animator.SetBool("isRun", true);
            player.velocity = new Vector2(5, player.velocity.y);
        }
        else if (player.velocity.x < -horSpeed)
        {
            animator.SetBool("RunLeft", true);
            animator.SetBool("RunRight", false);
            animator.SetBool("isRun", true);
            player.velocity = new Vector2(-5, player.velocity.y);
        }
        if (player.velocity.y > vertSpeed * 2)
        {
            player.velocity = new Vector2(player.velocity.x, vertSpeed);
        }
        else if (player.velocity.y < -vertSpeed * 2)
        {
            player.velocity = new Vector2(player.velocity.x, -vertSpeed);
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
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (h > 0)
        {
            PlayerController.player.direction = dir.right;
            transform.rotation = Quaternion.Euler(0, 0, 0);
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
        if (cameraArm.position.x > transform.position.x + 1)
        {
            cameraArm.position -= new Vector3(cameraSpeed, 0, 0);
        }
        else if (cameraArm.position.x < transform.position.x - 1)
        {
            cameraArm.position += new Vector3(cameraSpeed, 0, 0);
        }
        if (cameraArm.position.y > transform.position.y + 2)
        {
            cameraArm.position -= new Vector3(0, cameraSpeed, 0);
        }
        else if (cameraArm.position.y < transform.position.y)
        {
            cameraArm.position += new Vector3(0, cameraSpeed, 0);
        }

        if (player.velocity.x == 0)
        {
            cameraArm.position = Vector3.MoveTowards(cameraArm.position, new Vector3(transform.position.x, cameraArm.position.y, cameraArm.position.z), Time.deltaTime * 5);
        }
        //cameraArm.position = new Vector3(transform.position.x, transform.position.y + 3, cameraArm.position.z);
    }
}
