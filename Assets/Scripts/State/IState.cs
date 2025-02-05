public interface IState 
{
    public void OnIdle(CharacterObject characterObject);
    public void OnWalk(CharacterObject characterObject);
    public void OnBasicAttack (CharacterObject characterObject);
}
