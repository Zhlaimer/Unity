using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable] public class GameEvent : UnityEvent { }
[System.Serializable] public class TacticalModeEvent : UnityEvent<bool> { }
public class TacticalModeScript : MonoBehaviour
{
    public GameEvent OnAttack;

    private Animator anim;
    public WeaponCollision weapon;

    [Space]
    public bool isAiming;
    public bool dashing;

    [Space]
    [Header("Targets in radius")]
    public List<Transform> targets;
    public int targetIndex;
    public Transform aimObject;

    [Space]
    public AnimatorStateInfo animSta;
    void Start()
    {
        weapon.onHit.AddListener((target) => HitTarget(target));
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        animSta = anim.GetCurrentAnimatorStateInfo(0);
        //Attack
        if (Input.GetMouseButtonDown(0))
        {
            OnAttack.Invoke();
            if (!dashing)
            {
                Debug.Log(animSta.IsName("Locomotion"));
                Attack();
            }
        }
    }
    public void HitTarget(Transform x)
    {
        if (x.GetComponent<EnemyScript>() != null)
        {
            x.GetComponent<EnemyScript>().GetHit();
        }
    }
    void Attack()
    {
        if (animSta.IsName("Locomotion"))
        {
            anim.SetTrigger("slash");
        }
        else if (animSta.IsName("Attack_1") && animSta.normalizedTime > 0.5f)
        {
            anim.SetTrigger("slash2");
        }
    }
}
