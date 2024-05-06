namespace Sats.Models;

public class FractionsQuestion: ArithmaticBase
{
    public FractionsQuestion()
    {
        var random = new Random();
        Operator = AllOperator[random.Next(AllOperator.Length)];
        LeftNumerator = random.Next(1, 10);
        LeftDenominator = random.Next(1, 10);
        RightWholeNumber = random.Next(1, 10);

        switch (Operator)
        {
            case "+":
                AnswerNumerator = LeftNumerator + RightWholeNumber * LeftDenominator;
                AnswerDenominator = LeftDenominator;
                break;
            case "-":
                AnswerNumerator = LeftNumerator - RightWholeNumber * LeftDenominator;
                AnswerDenominator = LeftDenominator;
                break;
            case "x":
                AnswerNumerator = LeftNumerator * RightWholeNumber;
                AnswerDenominator = LeftDenominator;
                break;
            case "/":
                AnswerNumerator = LeftNumerator;
                AnswerDenominator = LeftDenominator * RightWholeNumber;
                break;
        }
        // correct the answer to the simplest form
        var gcd = GCD(AnswerNumerator, AnswerDenominator);
        AnswerNumerator /= gcd;
        AnswerDenominator /= gcd;
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public int LeftNumerator { get; }
    public int LeftDenominator { get; }
    public int RightWholeNumber { get; }
    public string? Operator { get; }
    public int AnswerNumerator { get; }
    public int AnswerDenominator { get; }
}