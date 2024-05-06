namespace Sats.Models;

public class ArithmeticQuestion: ArithmaticBase
{
    public ArithmeticQuestion()
    {
        var random = new Random();

        Operand1 = Math.Round(random.NextDouble() * (1000 - 10) + 10, 2);
        Operand2 = Math.Round(random.NextDouble() * (1000 - 10) + 10, 2);

        IsWholeNumber = random.Next(2) == 1;

        if (IsWholeNumber)
        {
            Operand1 =  Math.Ceiling(Operand1/100);
            Operand2 =  Math.Ceiling(Operand2/100);
            Operator = AllOperator[random.Next(AllOperator.Length)];
        }
        else
        {
            Operator = DivideMultipler[random.Next(DivideMultipler.Length - 1)];
        }
        
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
    
    public double Operand1 { get; }
    public double Operand2 { get; }
    public string? Operator { get; }
    public double Answer { get; }
    public bool IsWholeNumber { get; }
}

