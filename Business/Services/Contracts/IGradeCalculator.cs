namespace Business.Services.Contracts
{
    interface IGradeCalculator: IBusinessServiceMarker
    {
        decimal CalculateECTSMedianGrade(string username, int academicYear);
        decimal CalculateMedianGrade(string username, int academicYear);
    }
}