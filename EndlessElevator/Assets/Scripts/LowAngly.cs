using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class LowAngly : Debaf
{
    private const float angular = 2.0F;

    public override void DebafEffect(float duration, float effect)
    {
        base.DebafEffect(duration, effect);
    }

    public override void SetDebaff(float effect)
    {
        UseDebaf(effect);
    }

    public override void UnSetDebaff()
    {
        UseDebaf(angular);
    }

    public override void UseDebaf(float effect)
    {
        var rigiBody = this.GetComponent<Rigidbody2D>();
        rigiBody.angularDrag = effect;
    }
}
