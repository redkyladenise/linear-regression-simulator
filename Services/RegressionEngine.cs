using LinearRegressionSimulator.Models;

namespace LinearRegressionSimulator.Services;

public static class RegressionEngine
{
    public static RegressionResult Calculate(List<DataPoint> points)
    {
        var result = new RegressionResult();
        int n = points.Count;

        if (n < 2)
        {
            result.IsValid = false;
            result.ErrorMessage = "At least 2 data points are required.";
            return result;
        }

        result.MeanX = points.Average(p => p.X);
        result.MeanY = points.Average(p => p.Y);

        // sums for variance and covariance
        foreach (var p in points)
        {
            double xDev = p.X - result.MeanX;
            double yDev = p.Y - result.MeanY;
            result.SumCovariance += xDev * yDev;
            result.SumVariance += xDev * xDev;
        }

        if (result.SumVariance == 0)
        {
            result.IsValid = false;
            result.ErrorMessage = "Cannot calculate regression. All X values must not be identical.";
            return result;
        }

        // slope (b) and intercept (a)
        result.Slope = result.SumCovariance / result.SumVariance;
        result.Intercept = result.MeanY - (result.Slope * result.MeanX);

        // table rows
        foreach (var p in points)
        {
            double xDev = p.X - result.MeanX;
            double yDev = p.Y - result.MeanY;
            
            result.Rows.Add(new CalculationRow
            {
                X = p.X,
                Y = p.Y,
                XMinusXBar = xDev,
                YMinusYBar = yDev,
                Covariance = xDev * yDev,
                Variance = xDev * xDev,
                PredictedY = result.Intercept + (result.Slope * p.X)
            });
        }

        return result;
    }
}