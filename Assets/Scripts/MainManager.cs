using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text HighscoreText;
    private int highscorevalue;
    public GameObject GameOverText;
    
    public bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        LoadValues();
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i] * Mathf.RoundToInt(GameManager.Instance.difficulty);
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void LoadValues()
    {
        highscorevalue = GameManager.Instance.points[0];
        HighscoreText.text = "Best Score : " + GameManager.Instance.names[0] + " : " + GameManager.Instance.points[0];
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            /**
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            **/
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
      
        ShiftScores();
        GameManager.Instance.SaveName();
        HighscoreText.text = "Best Score : " + GameManager.Instance.names[0] + " : " + GameManager.Instance.points[0];

        GameOverText.SetActive(true);
        StartCoroutine(goDelay());
    }

    private void ShiftScores()
    {
        int addLocation = 0;
        while (addLocation < 5 && m_Points <= GameManager.Instance.points[addLocation])
        {
            addLocation++;
        }

        GameManager.Instance.points.Insert(addLocation, m_Points);
        GameManager.Instance.points.RemoveAt(5);
        GameManager.Instance.names.Insert(addLocation, GameManager.Instance.currentName);
        GameManager.Instance.names.RemoveAt(5);

    }

    IEnumerator goDelay()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
}
