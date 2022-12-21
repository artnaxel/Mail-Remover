using MailRemoverAPI.Interfaces;
namespace MailRemoverAPI.Services
{
    public class Co2FootprintCalcService : ICo2FootprintCalcService
    {
        public double Co2FootprintCalculatorKg(int bytes)
        {
            double calculatedCo2 = bytes * 0.0001;
            return calculatedCo2;
        }

        public int EggCalculator(int messagesTotal)
        {
            int calcEggs = messagesTotal * 2;
            return calcEggs;
        }

    }
}
