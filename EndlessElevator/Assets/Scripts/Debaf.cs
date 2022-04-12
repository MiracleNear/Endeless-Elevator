using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Debaf : MonoBehaviour
{
    private float _lastTime;

    public virtual void DebafEffect(float duration, float effect)
    {
        _lastTime = Time.time;
        this.StartCoroutine(startEffect(duration, effect));
    }


    public IEnumerator startEffect(float duration, float effect)
    {
        this.SetDebaff(effect);

        while(true)
        {
            var time = Time.time - _lastTime;
            if(time/duration >= 1)
            {
                this.UnSetDebaff();
                break;
            }
            yield return null;
        }
        

    }


    public abstract void SetDebaff(float effect);
    public abstract void UnSetDebaff();

    public abstract void UseDebaf(float effect);
     
}











