public class Player : PlayerController
{
    private PlayerController controller;
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        controller = this;
    }

    private int Health { get => controller.health; set => controller.health = value; }

}

