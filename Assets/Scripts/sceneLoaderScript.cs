using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class sceneLoaderScript : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public GameObject playButton;

    void Start()
    {
        Button button = playButton.gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { LoadScene(); });
    }
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadScene();
        }*/
    }

    public void LoadScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }
    

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
