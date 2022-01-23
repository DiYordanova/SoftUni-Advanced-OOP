namespace Telephony
{
    public class StationaryPhone : Phone
    {
        public override string Call(string number)
        {
            Validator.ThrowIfNumberIsInvalid(number);

            return $"Dialing... {number}";
        }
    }
}
