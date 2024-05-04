namespace Sats.Models;

public class FractionsQuestion: ArithmaticBase
{
    public FractionsQuestion()
    {
        var random = new Random();
        Operator = Operators[random.Next(Operators.Length)];
        Numerator1 = 2;//random.Next(1, 10);
        Denominator1 = 4;//random.Next(1, 10);
        Numerator2 = 3;//random.Next(1, 10);
        Denominator2 = 4;//random.Next(1, 10);
        
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