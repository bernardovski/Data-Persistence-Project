using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
    public Text playerName;
    public Text HighscoreText;

    public Slider difSlider;
    public Text difficultyText;

    // Start is called before the first frame update
    void Start()
    {
        HighscoreText.text = "Best Score : " + GameManager.Instance.names[0] + " : " + GameManager.Instance.points[0];
    }

    public void  StartNew()
    {
        GameManager.Instance.currentName = playerName.text;
        GameManager.Instance.difficulty = difSlider.value;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
       // GameManager.Instance.SaveName();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SetDifficulty()
    {
        switch (difSlider.value)
        {
            case 3:
                difficultyText.text = "Difficult";
                break;
            case 2:
                difficultyText.text = "Normal";
                break;
            case 1:
                difficultyText.text = "Easy";
                break;
        }
    }
}
