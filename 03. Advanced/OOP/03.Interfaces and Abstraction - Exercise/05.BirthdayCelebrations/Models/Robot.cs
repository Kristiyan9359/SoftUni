namespace _04.BorderControl.Models;

public class Robot
{
    private string model;
    private string id;

    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }

    public string Model { get; private set; }

    public string Id { get; private set; }
}
