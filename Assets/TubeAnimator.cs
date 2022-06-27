using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TubeAnimator : MonoBehaviour
{
    private Vector3 scaleOn = new Vector3(1.2f,1.2f,1.2f);
    private Vector3 defaultScale = Vector3.one;
    void Start()
    {
        StartAnimation();
    }

    private void StartAnimation()
    {
        transform.DOScale(scaleOn, 0.7f).OnComplete(() =>
        {
            transform.DOScale(defaultScale,0.7f);
        }).SetLoops(10000, LoopType.Restart);
    }

}
