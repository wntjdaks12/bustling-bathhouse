public class BasicAttackState : IState
{
    public static BasicAttackState Instance { get; } = new BasicAttackState();

    public void OnBasicAttack(CharacterObject characterObject)
    {
    }

    public void OnIdle(CharacterObject characterObject)
    {
        characterObject.animator.SetBool("IsWalking", false);

        characterObject.StateManager.State = IdleState.Instance;
    }

    public void OnWalk(CharacterObject characterObject)
    {
        characterObject.animator.SetBool("IsWalking", true);

        characterObject.StateManager.State = WalkState.Instance;
    }
}
