namespace BuilderDesignPatternSample.Models
{
    public class Meals
    {
        public string? MainCourse { get; set; }
        public string? SideDish { get; set; }
        public string? Drink { get; set; }

        public override string ToString()
        {
            return $"Main Course: {MainCourse}, Side Dish: {SideDish}, Drink: {Drink}";
        }

    }
}
