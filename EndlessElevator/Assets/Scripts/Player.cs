using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{



    private float _speed;
    private Vector2 _input;
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private GameObject _lift;
    private SoundManager soundManager;


    void Start()
    {
        _speed = 5.5f;
        _input = Vector2.zero;
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        _lift = GameObject.Find("Lift");
        soundManager = GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
        Move();
        ChangeAnim();
        Flip();
        
    }



    void InputPlayer()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
    }


   void Move()
    {
        var start = transform.position;
        var end = transform.position +  new Vector3(_input.x * _speed, 0);
        var diff = Vector3.MoveTowards(start, end, Time.deltaTime * _speed);
        transform.position = diff;
        

    }

    void ChangeAnim()
    {
        animator.SetFloat("Run", Mathf.Abs(_input.x));
    }


    void Flip()
    {
        transform.localRotation = Quaternion.Euler(0, 0, _lift.transform.eulerAngles.z);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            //var box = collision.gameObject.GetComponent<Box>();
            //var boxType = box.GetType();
            Destroy(collision.gameObject);
            soundManager.PlayClip();
            GameManager.instance.IncreaseScore();
            GameManager.instance.UpdateUi();
            
        }
    }
}
