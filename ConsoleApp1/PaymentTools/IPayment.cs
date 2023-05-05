namespace Cards.PaymentTools
{
    public interface IPayment
    {
        bool MakePayment(float sum);
        bool TopUp(float sum);
        float Amount();
    }
}
