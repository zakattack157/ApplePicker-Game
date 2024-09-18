using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Rounds : MonoBehaviour
{
    public int round = 1;
    private Text uiText;
    public ApplePicker applePicker;
    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RoundIncrement()
    {
        round += 1;
        uiText.text = "Round: " + round.ToString();
    }


    public void GameOver()
    {
        uiText.text = "Game Over, Play Again?";

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}
