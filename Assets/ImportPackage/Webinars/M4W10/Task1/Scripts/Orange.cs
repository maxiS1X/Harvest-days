using UnityEngine;
using System.Collections;

public class Orange : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return null;
    }
}
