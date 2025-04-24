using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class quizManager : MonoBehaviour
{
    public List<questionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public GameObject window;
    
    public Text questionText;

    private void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<answersScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];
            if (QnA[currentQuestion].correctAnswer == i + 1)
            {
                options[i].GetComponent<answersScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            questionText.text = QnA[currentQuestion].Question;
            setAnswers();
        }
        else
        {
            Debug.Log("Out of questions");
            window.SetActive(false);
        }

    }
}
