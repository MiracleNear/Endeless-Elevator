using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class LowFriction : Debaf
{
    private const float _standartFrtiction = 10f;
    [SerializeField] private PhysicsMaterial2D _material;

    public override void SetDebaff(float effect)
    {
        UseDebaf(effect);  
    }

    public override void UnSetDebaff()
    {
        UseDebaf(_standartFrtiction);
    }

    public override void UseDebaf(float effect)
    {
        _material.friction = effect;
        print(_material.friction);
    }
}
