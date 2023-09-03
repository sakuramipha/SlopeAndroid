using UnityEngine;
using System.Collections;

public class RotateSample : MonoBehaviour
{	
	void Start(){
		iTween.RotateBy(gameObject, iTween.Hash("time", 1, "delay", 0, "easeType", iTween.EaseType.easeOutQuad, "loopType",  iTween.LoopType.none));
	}
}

