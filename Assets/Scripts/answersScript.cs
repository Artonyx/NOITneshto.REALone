using UnityEngine;

public class answersScript : MonoBehaviour
{
    public bool isCorrect = false;
    public quizManager quizManager;

    public void Answer()
    {
        if (isCorrect) //проверява дали отговорът е правилен и отива на следващия въпрос ако да
        {
            Debug.Log("Correct");
            quizManager.correct();
            
        }
        else //ако не - затваря тривиата
        {
            Debug.Log("Incorrect");
            quizManager.window.SetActive(false);
        }
    }
}
