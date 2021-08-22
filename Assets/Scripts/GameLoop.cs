using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public List<GameAction> _initActions;

    private IEnumerator Start()
    {
        foreach (var action in _initActions)
        {
            yield return action?.Invoke();
        }
    }
}