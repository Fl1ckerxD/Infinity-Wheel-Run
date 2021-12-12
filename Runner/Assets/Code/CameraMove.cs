using UnityEngine;

public class CameraMove : MonoBehaviour
{
    /// <summary>
    /// Местонахождение персонажа
    /// </summary>
    [SerializeField] private Transform player;
    private Vector3 _offset;

    // Вычисление офсета для камеры
    void Start()
    {
        _offset = transform.position - player.position;
    }

    // Перемещение камеры
    void Update()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, _offset.z + player.position.z);
        transform.position = newPosition;
    }
}
