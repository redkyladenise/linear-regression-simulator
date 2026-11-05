namespace LinearRegressionSimulator.Models;

public class RegressionResult
{
    public double Slope { get; set; }   // SumCovariance/SumVariance
    public double Intercept { get; set; }   // MeanY - (Slope)(MeanX)
    public double MeanX { get; set; }
    public double MeanY { get; set; }
    public double SumCovariance { get; set; }
    public double SumVariance { get; set; }
    public List<CalculationRow> Rows { get; set; } = new();
    public bool IsValid { get; set; } = true;
    public string ErrorMessage { get; set; } = string.Empty;
}