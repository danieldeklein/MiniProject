public class Player
{

    public int CurrentHitPoints;
    public Location? CurrentLocation;
    public Weapon? CurrentWeapon;
    public int MaximumHitPoints;
    public string Name;

    public Player(string Name, int MaximumHitPoints)
    {
        CurrentHitPoints = 100;
        CurrentLocation = World.LocationByID(1);
        CurrentWeapon = World.WeaponByID(1);
        this.Name = Name;
        this.MaximumHitPoints = MaximumHitPoints;
    }

}