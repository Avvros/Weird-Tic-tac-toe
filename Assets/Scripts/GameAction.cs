using System.Collections;
using UnityEngine;

public abstract class GameAction : MonoBehaviour
{
    public abstract IEnumerator Invoke();
}