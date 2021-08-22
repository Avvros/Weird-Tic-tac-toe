using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameActionImpl : GameAction
{
    public UnityEvent OnInvoke;

    public override IEnumerator Invoke()
    {
        OnInvoke?.Invoke();
        yield return null;
    }
}
