using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GOManager : MonoBehaviour
{
    public Text player1Name;
    public Text player1Points;
    public Text player2Name;
    public Text player2Points;
    public Text player3Name;
    public Text player3Points;
    public Text player4Name;
    public Text player4Points;
    public Text player5Name;
    public Text player5Points;

    // Start is called before the first frame update
    void Start()
    {
        player1Name.text = GameManager.Instance.names[0];
        player1Points.text = GameManager.Instance.points[0].ToString();
        player2Name.text = GameManager.Instance.names[1];
        player2Points.text = GameManager.Instance.points[1].ToString();
        player3Name.text = GameManager.Instance.names[2];
        player3Points.text = GameManager.Instance.points[2].ToString();
        player4Name.text = GameManager.Instance.names[3];
        player4Points.text = GameManager.Instance.points[3].ToString();
        player5Name.text = GameManager.Instance.names[4];
        player5Points.text = GameManager.Instance.points[4].ToString();
    }

}
