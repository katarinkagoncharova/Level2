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
    }
}
