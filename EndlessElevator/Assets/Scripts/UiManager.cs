using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    [SerializeField] private Text _score;
    [SerializeField] private Text _endText;
    private int score;



    private void Start()
    {
        score = 0;
        UpdateUiScore();
    }


    public void UpdateUiScore()
    {
        var str = "Score: " + score.ToString();
        _score.text = str;
    }


    public void IncreaseScore()
    {
        score++;
    }

    public IEnumerator ViewEndGame()
    {
        var i = 1;
        var j = 1;
        while(!GameManager.instance._endGame)
        {
            if(i == 1)
            {
                j = 1;
            }
            if(i == 20)
            {
                j = -1;
            }
            _endText.fontSize = i;
            i += j;

            yield return new WaitForSeconds(0.1f);

        }

    }
    
    
}
