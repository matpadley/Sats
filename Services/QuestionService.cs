using Sats.Models;

namespace Sats.Services;

public class QuestionService
{
    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    

    public FractionsQuestion GenerateFractionsQuestion()
    {

        var question = new FractionsQuestion();

        

        return question;
    }
}