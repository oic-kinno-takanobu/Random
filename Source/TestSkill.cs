using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSkill : SkillBase {

    [SerializeField]
    float maxInactiveTime = 1;

    float inactiveTime;
    PlayerBase playerBase;
    // Use this for initialization
    void Start () {

        playerBase = transform.root.gameObject.GetComponent<PlayerBase>();
        base.Init();
    }

    // Update is called once per frame
    void Update () {
        SkillAction();
    }

    private void OnEnable()
    {
       
    }

    private void SkillAction()
    {
        inactiveTime += Time.deltaTime;
        if (inactiveTime >= maxInactiveTime)
        {
            playerBase.ChangeSkillFlg(false);
            inactiveTime = 0;
            gameObject.SetActive(false);
        }
    }
}
