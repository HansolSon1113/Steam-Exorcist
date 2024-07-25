using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerController : MonoBehaviour
{
<<<<<<< Updated upstream
    public PlayerValues playerValues;
    public static MovementController movementController;
    public static Damage damage;
=======
    public float horSpeed = 5f;
    public float vertSpeed = 5f;
    public Transform playerTransform;
    [SerializeField] Rigidbody2D player;
    [SerializeField] Transform cameraArm;
    [SerializeField] float gravityAmount = 1f;
    public static float h, v;
    public float cameraSpeed = 1f;
    private Animator animator;
>>>>>>> Stashed changes

    public void Awake()
    {
<<<<<<< Updated upstream
        player = playerValues.player;
        player.direction = playerValues.direction;
        player.isFlying = playerValues.isFlying;
        player.attackSpeed = playerValues.attackSpeed;
        damage = playerValues.damage;
        player.health = new Health(playerValues._health, playerValues._maxHealth, playerValues.barrier);
=======
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        Player.playerController = this;
>>>>>>> Stashed changes
    }

    public static IEnumerator Invincible()
    {
<<<<<<< Updated upstream
        player.isInvincible = true;
        yield return new WaitForSeconds(player.invDuration);
        player.isInvincible = false;
=======
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        animator.SetBool("RunRight",false);
        animator.SetBool("RunLeft", false);
        animator.SetBool("isRun",false) ;

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
            animator.SetBool("RunRight",true) ;
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
        if(player.velocity.y > vertSpeed)
        {
            player.velocity = new Vector2(player.velocity.x, vertSpeed);
        }
        else if (player.velocity.y < -vertSpeed)
        {
            player.velocity = new Vector2(player.velocity.x, -vertSpeed);
        }

        if (Player.isFlying)
        {
            player.AddForce(Vector3.down * gravityAmount);
        }
        else
        {
            player.AddForce(Vector3.up * v * vertSpeed, ForceMode2D.Impulse);
        }

        if (player.velocity.y > vertSpeed)
        {
            player.velocity = new Vector2(player.velocity.x, vertSpeed);
        }

        if (h < 0)
        {
            Player.direction = -1;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (h > 0)
        {
            Player.direction = 1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        UpdateCameraPosition();
>>>>>>> Stashed changes
    }

    public static Entity player { get; set; }
}
