using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DoRandomScale : MonoBehaviour {

    public float min = 5;
    public float max = 40;

    // Use this for initialization
    void Start ()
    {
        DoRandomStart();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void DoRandomStart()
    {
        float i = Random.Range(min, max);

        this.transform.DOScaleY(i, Random.Range(0.15f, 1f)).SetEase(Ease.OutBack).OnComplete(DoRandomStart);
    }
}
