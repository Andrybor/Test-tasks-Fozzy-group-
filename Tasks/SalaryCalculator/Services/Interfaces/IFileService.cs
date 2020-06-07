namespace SalaryCalculator.Helper
{
    public interface IFileService
    {
        void WriteToFile(string path);
        string ReadFromFile(string path);
    }
}
