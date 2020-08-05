using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorData : MonoBehaviour
{
    [Header("== Maximum Data ==")]
    [Range(0, 200)]
    public float HPMax = 100.0f;

    [Header("== Currect Data==")]
    [Range(0, 100f)]
    public float HP = 100f;
    public float ATK = 10;
    public float DEF = 0;
    public void AddHp(float value)
    {
        //增加生命值
        HP = HPRegulate(HP + value,0,HPMax);

    }

    private float HPRegulate(float value,float min, float max)
    {
        return Mathf.Clamp(HP, 0, HPMax);
    }
}
