public class Player
{
    public int CurrentHitPoints;
    public Location? CurrentLocation;
    public Weapon? CurrentWeapon;
    public int MaximumHitPoints;
    public string Name;
    private Random RandomNumberGenerator = new Random();

    public Player(string Name, int MaximumHitPoints)
    {
        CurrentHitPoints = 100;
        CurrentLocation = World.LocationByID(1);
        CurrentWeapon = World.WeaponByID(1);
        this.Name = Name;
        this.MaximumHitPoints = MaximumHitPoints;
    }
    public void Fight(Monster monster)
    {
        if (monster == null)
        {
            return;
        }

        while (CurrentHitPoints > 0 && monster.CurrentHitPoints > 0)
        {
            int damageToMonster = RandomNumberGenerator.Next(0, CurrentWeapon?.maximumDamage ?? 1);
            int damageToPlayer = RandomNumberGenerator.Next(0, monster.MaximumDamage);

            monster.CurrentHitPoints -= damageToMonster;
            Console.WriteLine($"You hit the {monster.Name} for {damageToMonster} points of damage.");
            Thread.Sleep(500);

            if (monster.CurrentHitPoints <= 0)
            {
                CurrentHitPoints = Math.Max(0, CurrentHitPoints - damageToPlayer);
                Console.WriteLine($"The {monster.Name} hit you for {damageToPlayer} points of damage.");
                Thread.Sleep(500);
                Console.WriteLine($"The {monster.Name} has been defeated!");
                if (CurrentHitPoints <= 0)
                {
                    Console.WriteLine("You have been defeated!");
                }
                else
                {
                    Console.WriteLine($"You have {CurrentHitPoints} hit points remaining.");
                }
            }
        }    
        monster.CurrentHitPoints = monster.MaximumHitPoints;
    }
    public void AddWeapon(){
        if (World.QuestByID(1).Completed)
        {
            CurrentWeapon = World.WeaponByID(2);
        }
    }

}