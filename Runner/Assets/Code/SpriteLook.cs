using UnityEngine;

public class SpriteLook : MonoBehaviour
{
    private Camera _cachedCamera;

    // Кэширование камеры
    private void Start()
    {
        _cachedCamera = Camera.main;
    }

    // Спрайт всегда повернут лицом к игроку
    void Update()
    {
        transform.LookAt(_cachedCamera.transform.position, -Vector3.up);
    }
}
