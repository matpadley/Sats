public class QuestionService

{
    private static readonly string[] Operators = { "+", "-", "x", "/" };

    public ArithmeticQuestion GenerateQuestion()
    {
        var random = new Random();
        var question = new ArithmeticQuestion
        {
            Operand1 = random.Next(1, 100),
            Operand2 = random.Next(1, 100),
            Operator = Operators[random.Next(Operators.Length)]
        };

        switch (question.Operator)
        {
            case "+":
                question.Answer = question.Operand1 + question.Operand2;
                break;
            case "-":
                question.Answer = question.Operand1 - question.Operand2;
                break;
            case "x":
                question.Answer = question.Operand1 * question.Operand2;
                break;
            case "/":
                // Ensure we don't divide by zero and the division is exact
                question.Operand1 = question.Operand1 * question.Operand2;
                question.Answer = question.Operand1 / question.Operand2;
                break;
        }

        return question;
    }
}