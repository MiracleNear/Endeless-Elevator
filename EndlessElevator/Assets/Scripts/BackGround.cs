using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject[] backGround;
    public List<GameObject> currentBackGround;


    private float _scrollSpedd;
    private float sizeY;
    void Start()
    {
        _scrollSpedd = 0.5f;
        var SpriteBack = backGround[0].GetComponent<SpriteRenderer>();
        sizeY = SpriteBack.size.y;
    }

    // Update is called once per frame
    void Update()
    {


        MoveBackGround();
        AddBackGround();
    }



    void MoveBackGround()
    {
        foreach(var back in currentBackGround)
        {
            var start = back.transform.position;
            var end = start + -back.transform.up * _scrollSpedd * Time.deltaTime;
            back.transform.position = end;
        }
    }


    void AddBackGround()
    {
        var add = false;
        foreach(var back in currentBackGround)
        {
            if(back.transform.position.y <= -sizeY)
            {
                add = true;
                remove(back);
                break;
            }
           
        }

        if(add)
        {
            var back = backGround[Random.Range(0, 100) % backGround.Length];
            var newBack = Instantiate(back, new Vector3(0, sizeY-_scrollSpedd, 0), Quaternion.identity);
            currentBackGround.Add(newBack);
        }
    }

    void remove(GameObject obj)
    {
        currentBackGround.Remove(obj);
        Destroy(obj);
        
    }
}
