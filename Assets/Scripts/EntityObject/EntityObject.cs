using UnityEngine;

public class EntityObject : PoolableObject
{
    [field : SerializeField] public Animator animator { get; private set; }
    [field: SerializeField] public AnimationHandler animationHandler { get; private set; }
    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }

    public Entity Entity { get; private set; }

    public GameObject localInstance { get; set; }

    public virtual void Init(Entity entity)
    {
        Entity = entity;

        if (Entity.Lifetime != 0 && gameObject.activeInHierarchy) StartCoroutine(Entity.StartLifeTime());
    }

    public void OnRemoveEntity()
    {
        ReturnPoolableObject();
    }
}
