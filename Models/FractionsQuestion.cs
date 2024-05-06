namespace Sats.Models;

public class FractionsQuestion: ArithmaticBase
{
    public FractionsQuestion()
    {
        var random = new Random();
        Operator = AllOperator[random.Next(AllOperator.Length)];
        LeftNumerator = random.Next(1, 10);
        LeftDenominator = random.Next(1, 10);
        RightNumerator = random.Next(1, 10);
        RightDenominator = random.Next(1, 10);
        
        switch (Operator)
        {
            case "+":
                AnswerNumerator = LeftNumerator * RightDenominator + RightNumerator * LeftDenominator;
                AnswerDenominator = LeftDenominator * RightDenominator;
                break;
            case "-":
                AnswerNumerator = LeftNumerator * RightDenominator - RightNumerator * LeftDenominator;
                AnswerDenominator = LeftDenominator * RightDenominator;
                break;
            case "x":
                AnswerNumerator = LeftNumerator * RightNumerator;
                AnswerDenominator = LeftDenominator * RightDenominator;
                break;
            case "/":
                AnswerNumerator = LeftNumerator * RightDenominator;
                AnswerDenominator = LeftDenominator * RightNumerator;
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
    
    // create a new model that will allow the same at ArithmeticQuestion, but for fractions
    public int LeftNumerator { get; }
    public int LeftDenominator { get; }
    public int RightNumerator { get; }
    public int RightDenominator { get; }
    public string? Operator { get; }
    public int AnswerNumerator { get; }
    public int AnswerDenominator { get; }
    
}