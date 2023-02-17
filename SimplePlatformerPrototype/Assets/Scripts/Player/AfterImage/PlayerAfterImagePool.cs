using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Player
{
    public class PlayerAfterImagePool : MonoBehaviour
    {
        [SerializeField] private GameObject afterImagePrefab;

        private Queue<GameObject> afterImageQueue = new();
        
        public static PlayerAfterImagePool instance;

        private void Awake()
        {
            instance = this;
            GrowPool();
        }

        private void GrowPool()
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject go = Instantiate(afterImagePrefab);
                go.transform.SetParent(transform);
                AddToPool(go);
            }
        }

        public void AddToPool(GameObject go)
        {
            go.SetActive(false);
            afterImageQueue.Enqueue(go);
        }
    
        public GameObject GetObjectFromPool()
        {
            if (afterImageQueue.Count <= 0) 
            {
                GrowPool();
            }
            GameObject go = afterImageQueue.Dequeue();
            go.SetActive(true);
            return go;
        }

    }
}
