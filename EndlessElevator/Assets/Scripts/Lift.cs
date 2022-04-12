using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] private Transform leftPointBalance;
    [SerializeField] private Transform RightPointBalance;

    private const float gravityForce = 9.81f;
    private SoundManager soundManager;
    private Rigidbody2D rigibodyLift;


    void Start()
    {
        rigibodyLift = GetComponent<Rigidbody2D>();
        soundManager = GetComponent<SoundManager>();
    }
    private void FixedUpdate()
    {
        if (transform.eulerAngles.z >= 180)
            rigibodyLift.AddForceAtPosition(new Vector2(0, -gravityForce), leftPointBalance.position);
        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z <= 90)
            rigibodyLift.AddForceAtPosition(new Vector2(0, -gravityForce), RightPointBalance.position);

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Box")
        {
            var box = collision.gameObject.GetComponent<Box>();
            var boxType = box.GetType();
            switch (boxType)
            {
                case Box.Boxes.Default:
                    UseForce(collision.transform, collision.transform.position - transform.position, box);
                    break;
                case Box.Boxes.DoubleWeightBox:
                    UseForce(collision.transform, collision.transform.position - transform.position, box);
                    break;
                case Box.Boxes.ExplodingBox:
                    var newDebafLowAngly = GetComponent<LowAngly>();
                    newDebafLowAngly.DebafEffect(Random.Range(2f, 4f), Random.Range(1.25f, 1.5f));
                    break;
                case Box.Boxes.FrictionReducingBox:
                    var newDebafLowFriction = GetComponent<LowFriction>();
                    newDebafLowFriction.DebafEffect(Random.Range(2f, 6f), Random.Range(0.5f, 2f));
                    break;
                       
            }
            soundManager.PlayClip();
            Destroy(collision.gameObject);
        }
    }


    private void UseForce(Transform point, Vector3 posAtForce, Box box)
    {
        rigibodyLift.AddForceAtPosition(-point.transform.up * Mathf.Abs(point.transform.position.x) * box.Force, posAtForce, ForceMode2D.Impulse);
    }

}
