using UnityEngine;

public class answersScript : MonoBehaviour
{
    public bool isCorrect = false;
    public quizManager quizManager;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct");
            quizManager.correct();
            
        }
        else
        {
            Debug.Log("Incorrect");
            quizManager.window.SetActive(false);
        }
    }
}
