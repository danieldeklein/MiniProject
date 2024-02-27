class Player
{

    public int CurrentHitPoints;
    public string CurrentLocation;
    public Weapon CurrentWeapon;
    public int MaximumHitPoints;
    public string Name;

    public Player(string Name, int MaximumHitPoints)
    {
        this.Name = Name;
        this.MaximumHitPoints = MaximumHitPoints;
    }

}