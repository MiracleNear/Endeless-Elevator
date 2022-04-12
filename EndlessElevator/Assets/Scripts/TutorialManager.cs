using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{

    [SerializeField] private Text startText;
    [SerializeField] private Text infoAboutGame;
    [SerializeField] private Text StartGame;
    [SerializeField] private GameObject[] _boxes;

    private string start = "Start";
    private string _text = "Базовое управление: A - движение влево, D - движение вправо";
    private string _textAboutBasicMechanic = "В этой игре вам предстоит собирать коробки или они вас заставят упасть на дно шахты!";
    private string _textAboutBoxes = "1 - самый обычный ящик, который воздействуют на платформу, заставляя её крутиться. 2 - ящик с удвоенной массой, который сильнее воздействует на платформу. 3 - ящик, который уменьшает угловое сопротивление, два предыдущих ящика начинают воздействовать сильней. 4 - ящик, который уменьшает трение, тебе будет сложнее удержаться на платформе.";

    
    void Start()
    {
        StartCoroutine(ViewStartText());
    }



    private IEnumerator ViewStartText()
    {
        var i = 0;
        while(i != _text.Length)
        {
            startText.text += _text[i];
            i++;
            yield return new WaitForSeconds(0.1f);
        }
        startText.text = "";
        StartCoroutine(ViewBasicMechanic());
    }


    public IEnumerator ViewBasicMechanic()
    {
        while(!(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
        {
            yield return null;
        }

        
        for(var i = 0; i < _textAboutBasicMechanic.Length; i++)
        {
            infoAboutGame.text += _textAboutBasicMechanic[i];
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.3f);
        infoAboutGame.text = "";

        for(var i = 0; i < _textAboutBoxes.Length; i++)
        {
            if (_textAboutBoxes[i] == '1')
            {
                _boxes[0].SetActive(true);
            }
            else if (_textAboutBoxes[i] == '2')
            {
                infoAboutGame.text = "";
                _boxes[0].SetActive(false);
                _boxes[1].SetActive(true);
            }
            else if(_textAboutBoxes[i] == '3')
            {
                infoAboutGame.text = "";
                _boxes[1].SetActive(false);
                _boxes[2].SetActive(true);
            }
            else if(_textAboutBoxes[i] == '4')
            {
                infoAboutGame.text = "";
                _boxes[2].SetActive(false);
                _boxes[3].SetActive(true);
            }

            infoAboutGame.text += _textAboutBoxes[i];
            
            yield return new WaitForSeconds(0.1f);
        }
        _boxes[3].SetActive(false);
        yield return new WaitForSeconds(0.3f);
        infoAboutGame.text = "";


        for(var i = 0; i < start.Length; i++)
        {
            StartGame.text += start[i];
            yield return new WaitForSeconds(0.1f);
        }
    }

    
}
