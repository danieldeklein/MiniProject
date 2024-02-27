class Quest 
{

    public string Description;
    public int ID;
    public string Name;

    public Quest(int ID, string Name, string Description)
    {
        this.Name = Name;
        this.ID = ID;
        this.Description = Description;
    }

}