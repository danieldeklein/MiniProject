public class Quest 
{

    public string Description;
    public int ID;
    public string Name;
    public bool Completed;

    public Quest(int ID, string Name, string Description)
    {
        this.Name = Name;
        this.ID = ID;
        this.Description = Description;
    }    
   
    public void DisplayQuestInfo()
    {
        Console.WriteLine($"Quest: {this.Name}");
        Console.WriteLine($"Description: {this.Description}");
    }
}