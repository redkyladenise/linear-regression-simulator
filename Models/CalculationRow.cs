namespace LinearRegressionSimulator.Models;

public class CalculationRow
{
    public double X { get; set; }
    public double Y { get; set; }
    public double XMinusXBar { get; set; }
    public double YMinusYBar { get; set; }
    public double Covariance { get; set; } // (x - x̄)(y - ȳ)
    public double Variance { get; set; }   // (x - x̄)²
    public double PredictedY { get; set; } // ŷ
}