public class StateManager
{
    private IState state;

    public StateManager()
    {
        state = IdleState.Instance;
    }

    public IState State { 
        get { return state; }
        set { state = value; }
    }
}
