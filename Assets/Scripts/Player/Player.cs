using UnityEngine;

public class Player : MonoBehaviour
{
    public static Entity player = new Entity();

    private void Start()
    {
        player.health = new Health(100, 100);
        player.isFlying = false;
    }

    public static PlayerController playerController;
    public static Health health { get; set; }
    public static int direction { get; set; }
    public static bool isFlying { get; set; }
}
