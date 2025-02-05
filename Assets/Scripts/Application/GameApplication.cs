using UnityEngine;

public class GameApplication : MonoBehaviour
{
    private static GameApplication instance;
    public static GameApplication Instance { get => instance ??= FindObjectOfType<GameApplication>(); }

    private GameModel gameModel;
    public GameModel GameModel 
    {
        get => gameModel ??= FindObjectOfType<GameModel>();
    }

    private EntityController entityController;
    public EntityController EntityController
    {
        get => entityController ??= FindObjectOfType<EntityController>();
    }

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Start()
    {
        Application.targetFrameRate = 60;
    }
}
