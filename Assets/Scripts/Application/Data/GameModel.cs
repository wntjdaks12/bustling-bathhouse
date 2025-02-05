using UnityEngine;

public class GameModel : MonoBehaviour
{
    // 사전에 정의된 비 휘발성 데이터
    private GameDataContainer presetData;
    public GameDataContainer PresetData
    {
        get => presetData ??= new GameDataContainer();
    }

    // 런타임 중 할당되는 휘발성 데이터
    private GameDataContainer runTimeData;
    public GameDataContainer RunTimeData
    {
        get => runTimeData ??= new GameDataContainer();
    }

    private void Awake()
    {
        // 비 휘발성 데이터 로드 ------------------------------------------------------------------------------------------
        PresetData.LoadData<PrefabInfo>(nameof(PrefabInfo), "JsonDatas/PrefabInfo"); // 프리팹 정보
        PresetData.LoadData<MiniHUD>(nameof(MiniHUD), "JsonDatas/MiniHUD"); // 미니 HUD
        PresetData.LoadData<LevelSpawnInfo>(nameof(LevelSpawnInfo), "JsonDatas/LevelSpawnInfo");  // 레벨 스폰 정보
        // ----------------------------------------------------------------------------------------------------------------
    }
}
