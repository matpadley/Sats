namespace Sats.Models;

public class ArithmeticQuestion: ArithmaticBase
{
    public ArithmeticQuestion()
    {
        var random = new Random();
        Operator = Operators[random.Next(Operators.Length)];
        Operand1 = random.Next(1, 10);
        Operand2 = random.Next(1, 10);
        
        switch (Operator)
        {
            case "+":
                Answer = Operand1 + Operand2;
                break;
            case "-":
                // Ensure the answer is always positive
                if (Operand1 < Operand2)
                {
                    (Operand1, Operand2) = (Operand2, Operand1);
                }
                Answer = Operand1 - Operand2;
                break;
            case "x":
                Answer = Operand1 * Operand2;
                break;
            case "/":
                // Ensure we don't divide by zero and the division is exact
                Operand1 *= Operand2;
                Answer = Operand1 / Operand2;
                break;
        }
    }
    
    public int Operand1 { get; }
    public int Operand2 { get; }
    public string? Operator { get; }
    public int Answer { get; }
}

