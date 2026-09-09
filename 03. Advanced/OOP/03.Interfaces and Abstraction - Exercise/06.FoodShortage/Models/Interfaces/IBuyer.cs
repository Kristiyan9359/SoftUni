namespace _06.FoodShortage.Models.Interfaces;

public interface IBuyer : INameable
{
    int Food { get; }
    void AddFood();
}
