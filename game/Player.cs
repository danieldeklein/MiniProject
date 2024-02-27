class Player
{

    public int CurrentHitPoints;
    public Location CurrentLocation;
    public Weapon CurrentWeapon;
    public int MaximumHitPoints;
    public string Name;

    public Player(string Name, int MaximumHitPoints)
    {
        this.Name = Name;
        this.MaximumHitPoints = MaximumHitPoints;
    }

}