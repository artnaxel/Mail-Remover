using MailRemoverAPI.Interfaces;
namespace MailRemoverAPI.Services
{
    public class Co2FootprintCalcService : ICo2FootprintCalcService
    {
        public double Co2FootprintCalculatorKgMessages(int messagesTotal)
        {
            double calculatedCo2 = messagesTotal * 0.5;
            return calculatedCo2;
        }

        public double Co2FootprintCalculatorKgKBytes(int size)
        {
            double calculatedCo2KBytes = size * 0.001;
            return calculatedCo2KBytes;
        }

        public int EggCalculator(int messagesTotal)
        {
            int calcEggs = messagesTotal * 2;
            return calcEggs;
        }

    }
}
