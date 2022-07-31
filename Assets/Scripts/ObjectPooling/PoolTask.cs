﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.ObjectPooling
{
    public class PoolTask 
    {
        private readonly List<IPoolable> _freeObjects;
        private readonly List<IPoolable> _objectsInUse;
        private readonly Transform _container;

        public PoolTask(Transform transform)
        {
            _objectsInUse = new List<IPoolable>();
            _freeObjects = new List<IPoolable>();
            _container = transform;
        }

        public T GetFreeObject<T>(T prefab) where T : MonoBehaviour, IPoolable
        {
            T obj;
            if (_freeObjects.Count > 0)
            {
                obj = _freeObjects.Last() as T;
                obj.GameObject.SetActive(true);
                _freeObjects.Remove(obj);
            }
            else
            {
                obj =  Object.Instantiate(prefab);
            }
            _objectsInUse.Add(obj);
            obj.OnReturnToPool += ReturnToPool;
            return obj;
        }

        private void ReturnToPool(IPoolable obj)
        {
            _freeObjects.Add(obj);
            _objectsInUse.Remove(obj);
            obj.OnReturnToPool -= ReturnToPool;
            obj.GameObject.SetActive(false);
            obj.Transform.SetParent(_container);
        }

        public void ReturnAllToPool()
        {
            foreach (var obj in _objectsInUse)
            {
                ReturnToPool(obj);
            }
        }

        public void ClearPool()
        {
            foreach (var obj in _objectsInUse)
            {
                Object.Destroy(obj.GameObject);
            }

            foreach (var obj in _freeObjects)
            {
                Object.Destroy(obj.GameObject);
            }
        }
    }
}