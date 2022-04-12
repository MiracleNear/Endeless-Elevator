using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private const float _gravityScale = 9.81f;
    private Rigidbody2D rigidbody2D;

    [SerializeField] private Boxes _boxes;


    public enum Boxes
    {
        Default,
        DoubleWeightBox,
        ExplodingBox,
        FrictionReducingBox,
    }

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        switch (_boxes)
        {
            case Boxes.Default:
                rigidbody2D.mass = Random.Range(0.25f, 0.5f);
                break;
            case Boxes.DoubleWeightBox:
                rigidbody2D.mass = Random.Range(0.75f, 1.5f);
                break;
            default:
                rigidbody2D.mass = 0f;
                break;

        }
    }

    public float Force
    {
        get
        {
            return rigidbody2D.mass * _gravityScale;
        }
    }

   
    public Boxes GetType()
    {
        return _boxes;
    }
}
