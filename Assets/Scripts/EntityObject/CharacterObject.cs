using UnityEngine;

public class CharacterObject : ActorObject
{
    // 캐릭터 데이터
    public Character Character { get; private set; }

    [field: SerializeField] 
    public Transform MiniHUDNode { get; private set; }
    [field: SerializeField]
    public Transform ProjectileNode { get; private set; }

    public StateManager StateManager { get; private set; }

    private void Awake()
    {
        RegisterEvent();
    }

    public override void Init(Entity entity)
    {
        base.Init(entity);

        if (entity is Character) Character = entity as Character;

        StateManager = new StateManager();
        StateManager.State.OnIdle(this);
    }

    public virtual void OnIde()
    {
        StateManager.State.OnIdle(this);
    }

    public virtual void OnMove(Vector3 dir, float speed)
    {
        transform.Translate(dir * Time.deltaTime * speed, Space.World);

        StateManager.State.OnWalk(this);
    }

    public virtual void OnBasicAttack()
    {
        StateManager.State.OnBasicAttack(this);

        animationHandler.StartAttackAnimation();
    }

    public virtual void OnSkill()
    {
        StateManager.State.OnBasicAttack(this);

        animationHandler.StartAttackAnimation();
    }

    private void RegisterEvent()
    {
        animationHandler.OnTriggerAttackEvent += () =>
        {
        };
    }
}
