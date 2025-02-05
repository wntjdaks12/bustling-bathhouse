public class WalkState : IState
{
    public static WalkState Instance { get; } = new WalkState();
    public void OnBasicAttack(CharacterObject characterObject)
    {
        characterObject.animator.SetTrigger("OnBasicAttack");

        characterObject.StateManager.State = BasicAttackState.Instance;
    }

    public void OnIdle(CharacterObject characterObject)
    {
        characterObject.animator.SetBool("IsWalking", false);

        characterObject.StateManager.State = IdleState.Instance;
    }

    public void OnWalk(CharacterObject characterObject)
    {
    }
}
