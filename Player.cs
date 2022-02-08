public class Player
{
    public string PlayerName { get; private set; }
    public string PlayerClass { get; private set; }
    public int PlayerHealth { get; private set; }
    public int PlayerStrength { get; private set; }
    public int PlayerIntelligence { get; private set; }
    public int PlayerAgility { get; private set; }
    public InventorySystem PlayerInventory { get; private set; }
    public Position PlayerPosition { get; private set; }

    public Player(string playerName, string playerClass, int playerHealth, int playerStrength, int playerIntelligence, int playerAgility, InventorySystem playerInventory, Position playerPosition)
    {
        PlayerName = playerName;
        PlayerClass = playerClass;
        PlayerHealth = playerHealth;
        PlayerStrength = playerStrength;
        PlayerIntelligence = playerIntelligence;
        PlayerAgility = playerAgility;
        PlayerInventory = playerInventory;
        PlayerPosition = playerPosition;
    }

}
