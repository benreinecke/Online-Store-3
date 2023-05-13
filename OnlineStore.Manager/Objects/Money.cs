public class Money
{
    public string centsToString(int cents)
    {
        string moneyString = cents.ToString();
        int stringLength = moneyString.Length;
        if (cents > 99)
        {
            moneyString = moneyString.Substring(0, stringLength - 2) + "." + moneyString.Substring(stringLength - 2, 2);
        }
        else if (cents > 9)
        {
            moneyString = "." + moneyString;
        }
        else
        {
            moneyString = ".0" + moneyString;
        }
        return moneyString;
    }
}
