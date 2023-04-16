namespace Cards
{
    public interface IPayment
    {
        bool MakePayment(float sum);
        bool TopUp(float sum);
    }
}
