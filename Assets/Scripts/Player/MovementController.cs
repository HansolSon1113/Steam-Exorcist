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

        if (h != 0)
        {
            player.AddForce(new Vector2(h * horSpeed, 0), ForceMode2D.Impulse);
            animator.SetBool("isRun", false);
        }
        else
        {
            player.velocity = new Vector2(player.velocity.x * 0.1f, player.velocity.y);
            animator.SetBool("isRun",true);
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
            cameraArm.position -= new Vector3(0, cameraSpeed * (1 + Mathf.Abs(cameraArm.position.y - transform.position.y)) * 0.5f, 0);
        }
        else if (cameraArm.position.y < transform.position.y)
        {
            cameraArm.position += new Vector3(0, cameraSpeed * (1 + Mathf.Abs(cameraArm.position.y - transform.position.y)) * 0.5f, 0);
        }

        if (Mathf.Abs(player.velocity.x) <= 1)
        {
            cameraArm.position = Vector3.MoveTowards(cameraArm.position, new Vector3(transform.position.x, cameraArm.position.y, cameraArm.position.z), Time.deltaTime * 5 * (1 + Mathf.Abs(cameraArm.position.x - transform.position.x)));
        }
        //cameraArm.position = new Vector3(transform.position.x, transform.position.y + 3, cameraArm.position.z);
    }
}
