using System.Collections.Generic;
using UnityEngine;

public class EntitiesPool<T> where T : MonoBehaviour
{
    private const bool DefaultAutoExpand = false;

    private T _prefab;
    private bool _autoExpand;
    private Transform _conteiner;
    private List<T> _pool;

    public EntitiesPool(T prefab,  int count, Transform container) 
    {
        _prefab = prefab;
        _conteiner = container;
        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        _pool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        T createdObject = Object.Instantiate(_prefab, _conteiner);
        createdObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createdObject);

        return createdObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var entity in _pool)
        {
            if(entity.gameObject.activeInHierarchy == false)
            {
                entity.gameObject.SetActive(true);
                element = entity;
                return true;
            }
        }

        element = null; 
        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out var element) == true)
            return element;

        if (_autoExpand == true)
        {
            return CreateObject(true);
        }

        throw new System.Exception($"There is no free element in pool of type {typeof(T)}");
    }

    public void SetAutoExpand(bool autoExpand = DefaultAutoExpand)
    {
        _autoExpand = autoExpand;
    }
}