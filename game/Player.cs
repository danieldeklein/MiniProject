class Player
{

    public int CurrentHitPoints;
    public Location CurrentLocation;
    public Weapon CurrentWeapon;
    public int MaximumHitPoints;
    public string Name;

    public Player(string Name, int MaximumHitPoints)
    {
        CurrentHitPoints = 100;
        CurrentLocation = new Location(0, "Home", "Home", null, null);
        CurrentWeapon = new Weapon(0, "First", 1);
        this.Name = Name;
        this.MaximumHitPoints = MaximumHitPoints;
    }

}