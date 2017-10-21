using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI_GameOverScreen : MonoBehaviour {

    Vector3 start;

    // Use this for initialization
    void OnEnable()
    {
        start = transform.position;
        transform.DOLocalMove(Vector3.zero, 1.0f);
    }

    public void Reset()
    {
        transform.localPosition = start;
        gameObject.SetActive(false);
    }

    // wow, much happen, very able
    public void Enable()
    {
        gameObject.SetActive(true);
    }
}
