using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_Countdown : MonoBehaviour {

    public Vector3 start;
    public RectTransform target;
    public Text text;

    private void Awake()
    {
        start = transform.localPosition;
    }

    public void OnEnable()
    {
        transform.localPosition = start;
        transform.DOLocalMove(target.localPosition, 1.5f).OnComplete(Next1);
        text.text = "3...";

    }

    private void Next1()
    {
        transform.localPosition = start;
        transform.DOLocalMove(target.localPosition, 1.5f).OnComplete(Next2);
        text.text = "2...";
    }

    private void Next2()
    {
        transform.localPosition = start;
        transform.DOLocalMove(target.localPosition, 1.5f).OnComplete(Next3);
        text.text = "1...";
    }

    private void Next3()
    {
        transform.localPosition = start;
        transform.DOLocalMove(target.localPosition, 1.5f).OnComplete(() => gameObject.SetActive(false));
        text.text = "GO! GO! GO!";
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }
}
