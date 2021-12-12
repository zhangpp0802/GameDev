using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button yourButton;
    public Menu PauseMenu;
    public Menu ContinueMenu;

    private void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        //btn.onClick.AddListener(StartButton);
        //btn.onClick.AddListener(RestartButton);
        //btn.onClick.AddListener(PauseButton);
    }

    public void Setup()
    {
        gameObject.SetActive(true);
        //pointsText.text = "POINTS: " + score.ToString();

    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        ScoreKeeper.ScorePoints((-1) * ScoreKeeper.get_score());
    }

    public void StartButton()
    {
        Time.timeScale = 1;
        //Destroy();
        // UnityEngine.Debug.Log("StartButton");

        gameObject.SetActive(false);
        PauseMenu.Setup();
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        //UnityEngine.Debug.Log("PauseButton");
        gameObject.SetActive(false);
        ContinueMenu.Setup();
    }
}
