using MailRemoverAPI.Interfaces;
namespace MailRemoverAPI.Services
{
    public class Co2FootprintCalcService : ICo2FootprintCalcService
    {
        public double Co2FootprintCalculatorKg(int messagesTotal)
        {
            double calculatedCo2 = messagesTotal * 0.5;
            return calculatedCo2;
        }

        public int EggCalculator(int messagesTotal)
        {
            int calcEggs = messagesTotal * 2;
            return calcEggs;
        }

    }
}
