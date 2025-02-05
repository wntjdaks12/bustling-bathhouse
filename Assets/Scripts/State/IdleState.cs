public class IdleState : IState
{
    public static IdleState Instance { get; } = new IdleState();

    public void OnBasicAttack(CharacterObject characterObject)
    {
        characterObject.animator.SetTrigger("OnBasicAttack");

        characterObject.StateManager.State = BasicAttackState.Instance;
    }

    public void OnIdle(CharacterObject characterObject)
    {
    }

    public void OnWalk(CharacterObject characterObject)
    {
        characterObject.animator.SetBool("IsWalking", true);

        characterObject.StateManager.State = WalkState.Instance;
    }
}
