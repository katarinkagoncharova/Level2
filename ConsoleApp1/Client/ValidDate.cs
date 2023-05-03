namespace Cards.Client
{
    public class ValidDate
    {
        private int _month;
        private int _year;
        public int Month
        {
            get
            {
                return _month;
            }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentOutOfRangeException("value must be between 1 and 12 ");
                }
                _month = value;
            }
        }
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Year cannot be negative");
                }
                _year = value;
            }
        }

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
