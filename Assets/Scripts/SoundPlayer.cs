using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;
using DG.Tweening;

public class SoundPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            InstanciateSound("event:/sfx/explosions/car",2 ,  1, false, Vector3.one, Vector3.zero);
        }
	}

    void InstanciateSound(string eventName, float delay, float volume, bool loop, Vector3 pos, Vector3 endPos, float tweenDuration = 2)
    {

        GameObject newGO = new GameObject(eventName + "Emitter")  as GameObject;//Instantiate(prefabEmitter, pos, Quaternion.identity) as GameObject;
        newGO.transform.position = pos;
        StudioEventEmitter newEmitter = newGO.AddComponent<StudioEventEmitter>() as StudioEventEmitter;
        if(endPos != Vector3.zero)
        {
            newGO.transform.DOMove(endPos, tweenDuration);
        }
        newEmitter.Event = eventName;
        newEmitter.Play();
    }
}
