public class Player
{
    string PlayerName { get; set; }
    string PlayerClass { get; set; }
    int PlayerHealth { get; set; }
    int PlayerStrength { get; set; }
    InventorySystem PlayerInventory { get; set; }
    public Position PlayerPosition { get; set; }

    public Player(string playerName, string playerClass, int playerHealth, int playerStrength, InventorySystem playerInventory, Position playerPosition)
    {
        PlayerName = playerName;
        PlayerClass = playerClass;
        PlayerHealth = playerHealth;
        PlayerStrength = playerStrength;
        PlayerInventory = playerInventory;
        PlayerPosition = playerPosition;
    }

}
