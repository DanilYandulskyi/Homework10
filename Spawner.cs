using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{   
    [SerializeField] private T _prefab;

    public T Spawn()
    {
        return Instantiate(_prefab, transform.position + Vector3.right, Quaternion.identity);
    }
}
