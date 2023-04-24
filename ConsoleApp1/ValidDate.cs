namespace Cards
{
    public class ValidDate
    {
        public int Month { get; set; }
        public int Year { get; set; }

        public ValidDate(int month, int year) 
        {
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return Month + "/" + Year;
        }

        public override bool Equals(object? obj)
        {
            if (obj is ValidDate other) 
            {
                return Month == other.Month && Year == other.Year;
            }
            return false;
        }
    }
}
