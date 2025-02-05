using System;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    public Action<EntityObject> OnEntitySpawn; 

    /// <summary>
    /// ��ƼƼ�� �����մϴ�.
    /// </summary>
    /// <typeparam name="T">��ƼƼ</typeparam>
    /// <param name="id">���̵�</param>
    /// <returns>��ƼƼ�� �����մϴ�.</returns>
    public T Spawn<T>(int id) where T : Entity
    {
        var entity = GameApplication.Instance.GameModel.RunTimeData.AddData(typeof(T).ToString(), id) as T;
        entity.Init();

        return entity;
    }

    /// <summary>
    /// ��ƼƼ�� ��ƼƼ ������Ʈ�� �����մϴ�.
    /// </summary>
    /// <typeparam name="T">��ƼƼ</typeparam>
    /// <typeparam name="K">��ƼƼ ������Ʈ</typeparam>
    /// <param name="id">���̵�</param>
    /// <param name="position">���� ��ġ</param>
    /// <param name="rotation">���� ȸ��</param>
    /// <param name="parent">�θ� ���� ����</param>
    /// <param name="value1">�ӽ� ������1</param>
    /// <returns>��ƼƼ ������Ʈ�� �����մϴ�.</returns>
    public K Spawn<T, K>(int id, Vector3 position, Quaternion rotation, Transform parent = null) where T : Entity where K : EntityObject
    {
        var runTimeData = GameApplication.Instance.GameModel.RunTimeData;

        var entity = runTimeData.AddData(typeof(T).ToString(), id) as T;

        var prefabInfo = GameApplication.Instance.GameModel.PresetData.ReturnData<PrefabInfo>(nameof(PrefabInfo), id);

        var entityObj = PoolObjectContainer.CreatePoolObject<K>(prefabInfo.Path);
        entityObj.gameObject.SetActive(false);

        if (rotation != Quaternion.identity) entityObj.transform.rotation = rotation;

        entityObj.transform.position = position;

        if (parent != null) entityObj.transform.SetParent(parent, false);

        entityObj.gameObject.SetActive(true);

        entity.Init(entityObj.transform);
        entityObj.Init(entity);

        entity.OnDataRemove += (data) =>
        {
            RemoveEntity(data);
        };

        runTimeData.AddData($"{typeof(T).Name}Object", entity.InstanceId, entityObj);

        if (entityObj.transform.parent != null)
        {
            var layerName = LayerMask.LayerToName(entityObj.transform.parent.gameObject.layer);
            ChangeLayersRecursively(entityObj.transform, layerName);
        }

        OnEntitySpawn?.Invoke(entityObj);

        return entityObj;
    }

    public void RemoveEntity(IData data)
    {
        var runTimeData = GameApplication.Instance.GameModel.RunTimeData;

        var entityObjectTableName = $"{data.TableModel.TableName}Object";
        var entityObject = runTimeData.ReturnData<EntityObject>(entityObjectTableName, data.InstanceId);

        if (entityObject != null)
        {
            entityObject.OnRemoveEntity();

            runTimeData.RemoveData(data.TableModel.TableName, data.InstanceId);
            runTimeData.RemoveData(entityObjectTableName, data.InstanceId);

            if (entityObject.transform.parent != null) entityObject.transform.SetParent(null, false);
        }
    }

    public void ChangeLayersRecursively(Transform trans, string name)
    {
        trans.gameObject.layer = LayerMask.NameToLayer(name);
        foreach (Transform child in trans)
        {
            ChangeLayersRecursively(child, name);
        }
    }
}
