namespace Sats.Models;

public class FractionsQuestion: ArithmaticBase
{
    public FractionsQuestion()
    {
        var random = new Random();
        Operator = Operators[random.Next(Operators.Length)];
        Numerator1 = random.Next(1, 10);
        Denominator1 = random.Next(1, 10);
        Numerator2 = random.Next(1, 10);
        Denominator2 = random.Next(1, 10);
        
        switch (Operator)
        {
            case "+":
                AnswerNumerator = Numerator1 * Denominator2 + Numerator2 * Denominator1;
                AnswerDenominator = Denominator1 * Denominator2;
                break;
            case "-":
                AnswerNumerator = Numerator1 * Denominator2 - Numerator2 * Denominator1;
                AnswerDenominator = Denominator1 * Denominator2;
                break;
            case "x":
                AnswerNumerator = Numerator1 * Numerator2;
                AnswerDenominator = Denominator1 * Denominator2;
                break;
            case "/":
                AnswerNumerator = Numerator1 * Denominator2;
                AnswerDenominator = Denominator1 * Numerator2;
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
    public int Numerator1 { get; }
    public int Denominator1 { get; }
    public int Numerator2 { get; }
    public int Denominator2 { get; }
    public string? Operator { get; }
    public int AnswerNumerator { get; }
    public int AnswerDenominator { get; }
    
}