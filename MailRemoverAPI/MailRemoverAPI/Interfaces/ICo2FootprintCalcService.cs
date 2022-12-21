using MailRemoverAPI.Services;
namespace MailRemoverAPI.Interfaces
{
    public interface ICo2FootprintCalcService
    {
        public double Co2FootprintCalculatorKg(int bytes);
        public int EggCalculator(int messagesTotal);
    }
}
