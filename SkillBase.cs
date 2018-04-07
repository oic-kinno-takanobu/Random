using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour {

    protected int consumptionSp;

    // Use this for initialization
    protected void Init () {
        gameObject.SetActive(false);
	}
}
