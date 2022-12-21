using MailRemoverAPI.Services;
namespace MailRemoverAPI.Interfaces
{
    public interface ICo2FootprintCalcService
    {
        public double Co2FootprintCalculatorKg(int messagesTotal);

        public double Co2FootprintCalculatorKgKBytes(int size);
        public int EggCalculator(int messagesTotal);
    }
}
