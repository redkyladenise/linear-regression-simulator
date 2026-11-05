namespace LinearRegressionSimulator.Models;

public class DataPoint
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public double X { get; set; }
    public double Y { get; set; }
}