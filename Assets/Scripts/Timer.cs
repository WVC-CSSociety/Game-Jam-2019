using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Tooltip("Time before the action is run in seconds.")]
    public float waitTime;

    public bool runOnStart = true;

    public UnityEngine.Events.UnityEvent action;

    // Use this for initialization
    void Start()
    {
        if (runOnStart) StartCoroutine(Run());
    }

    public void StartCounting()
    {
        StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        yield return new WaitForSeconds(waitTime);

        if (action != null) action.Invoke();
    }
}
