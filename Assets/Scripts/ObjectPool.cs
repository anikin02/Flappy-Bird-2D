using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private int capacity;

    private Camera camera;

    private List<GameObject> pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        camera = Camera.main;

        for (int i = 0; i < capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, container.transform);
            spawned.SetActive(false);

            pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }

    protected void DisableObjectAbroadScreen()
    {   
        Vector3 disablePoint = camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

        foreach (var item in pool)
        {
            if (item.activeSelf == true)
            {
                if (item.transform.position.x + 25 < disablePoint.x)
                {
                    item.SetActive(false);
                }
            }
        }
    }

    public void ResetPool()
    {
        foreach (var item in pool)
        {
            item.SetActive(false);
        }
    }
}
