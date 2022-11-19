namespace MailRemoverAPI.Services
{
    public class Co2FootprintCalc
    {
        public double Co2toKg(int Mb)
        {
            double calculated = (double)(Mb * 0.019);
            return calculated;
        }

        public async Task<long?> ToGrams(int Mb)
        {
            return Convert.ToInt64(this.Co2toKg(Mb) * 1000000);
        }

        public async Task<double?> ToTonns(int Mb)
        {
            return (double)(this.Co2toKg(Mb) / 1000000);
        }

    }
}

