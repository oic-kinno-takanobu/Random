using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour {

    const string SKILL_OBJ_NAME_1 = "TestObj1";

    float horizontal;
    float vertical;

    [SerializeField]
    float roteSpeed = 1.0f;

    [SerializeField]
    float moveSpeed = 1.0f;

    [SerializeField]
    float avoidanceSpeed = 7.5f;

    [SerializeField]
    Transform cameraAngle;

    bool avoidanceFlg = false;
    [SerializeField]
    float maxAvoidanceTime = 0.2f;
    float avoidanceTime;

    bool skillFlg;

    GameObject skillObj1;
    GameObject skillObj2;

    // Use this for initialization
    void Awake () {
        //本来ならここでデータを呼び出しをする
        GameObject skillObj = (GameObject)Instantiate((GameObject)Resources.Load(passConst.SKILL_PASS + SKILL_OBJ_NAME_1));
        skillObj.transform.parent = gameObject.transform;
        skillObj.transform.localPosition = new Vector3(0,0,0);
        skillObj1 = skillObj;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        Avoidance();
        SkillAttack();
    }

    /// <summary>
    /// 移動
    /// </summary>
    void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if ((horizontal == 0 && vertical == 0) || avoidanceFlg || skillFlg)
        {
            return;
        }

        float step = roteSpeed * Time.deltaTime;
        float inputAngle = Mathf.Atan2(horizontal, vertical) / Mathf.PI * 180 + cameraAngle.eulerAngles.y;
        float angle = Mathf.LerpAngle(transform.eulerAngles.y, inputAngle, step);
        transform.eulerAngles = new Vector3(0, angle, 0);

        float distans = Mathf.Sqrt(horizontal * horizontal + vertical * vertical);
        transform.position += transform.forward * moveSpeed * distans * Time.deltaTime;
    }

    /// <summary>
    /// 回避
    /// </summary>
    void Avoidance()
    {
        if (avoidanceFlg)
        {
            avoidanceTime += Time.deltaTime;

            transform.position += transform.forward * avoidanceSpeed * Time.deltaTime;

            if (avoidanceTime >= maxAvoidanceTime)
            {
                avoidanceTime = 0;
                avoidanceFlg = false;
            }
        }
        else if (Input.GetButtonDown("Jump"))
        {
            avoidanceFlg = true;

            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            if (horizontal != 0 || vertical != 0)
            {
                float inputAngle = Mathf.Atan2(horizontal, vertical) / Mathf.PI * 180 + cameraAngle.eulerAngles.y;
                transform.eulerAngles = new Vector3(0, inputAngle, 0);
            }
           
        }
    }

    /// <summary>
    /// スキル攻撃
    /// </summary>
    void SkillAttack()
    {
        if (skillFlg)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            skillObj1.SetActive(true);
            ChangeSkillFlg(true);
        }
    }

    public void ChangeSkillFlg(bool trigger)
    {
        skillFlg = trigger;
    }
}
