using System;
using System.Collections;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public event Action OnTriggerAttackEvent;

    public bool IsAttacking { get; private set; }

    /// <summary>
    /// 공격 시작
    /// </summary>
    public void StartAttackAnimation()
    {
        IsAttacking = true;

        StartCoroutine(TempAniamtionAsynv());
    }

    public void TriggerAttack()
    {
        OnTriggerAttackEvent?.Invoke();
    }

    /// <summary>
    /// 공격 끝
    /// </summary>
    public void ExitAttackAnimation()
    {
        IsAttacking = false;
    }

    private IEnumerator TempAniamtionAsynv()
    {
        yield return new WaitForSeconds(1f);

        ExitAttackAnimation();
    }

}
