using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Audio _sound;
    private CharacterController _controller;
    public GameObject deadPanel;
    public GameObject[] skinPlayer;
    private Animator _anim;
    private Vector3 _vec3;
    public enum ControlType {Andorid, PC};
    public ControlType controlType;

    /// <summary>
    /// Параметры игрока
    /// </summary>
    public int speed;
    public int jumpPower;
    private int numLine = 1;
    public float lineDistance = 4;
    public float gravity;

    // Кэширование файлов
    void Start()
    {      
        _controller = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
        _sound = FindObjectOfType<Audio>();
        deadPanel.SetActive(false);
        Wear(Store.skin);
    }

    // Перемещение игрока в зависимости от типа платформы
    private void Update()
    {
        if(controlType == ControlType.Andorid)
        {
            if (SwitchController.swipeRight)
            {
                if (numLine < 2)
                    numLine++;
            }
            if (SwitchController.swipeLeft)
            {
                if (numLine > 0)
                    numLine--;
            }
            if (SwitchController.swipeUp)
            {
                if (_controller.isGrounded)
                    Jump();
            }
        }

        else if(controlType == ControlType.PC)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (numLine < 2)
                    numLine++;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (numLine > 0)
                    numLine--;
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                if (_controller.isGrounded)
                    Jump();
            }
        }


        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (numLine == 0)
            targetPosition += Vector3.left * lineDistance;
        else if (numLine == 2)
            targetPosition += Vector3.right * lineDistance;

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            _controller.Move(moveDir);
        else
            _controller.Move(diff);
    }

    // Проявление гравитации на игорке
    void FixedUpdate()
    {
        _vec3.z = speed;
        _vec3.y += gravity * Time.fixedDeltaTime;
        _controller.Move(_vec3 * Time.fixedDeltaTime);
    }

    // Прыжок
    private void Jump()
    {
        _sound.Effects(3);
        _vec3.y = jumpPower;
    }

    // Проигрыш 
    public void Dead()
    {
        _sound.Effects(2);
        _anim.SetTrigger("dead");
        deadPanel.SetActive(true);
    }

    // Установка выбранного скина
    private void Wear(int color)
    {
        for (int i = 0; i < skinPlayer.Length; i++)
        {
            skinPlayer[i].SetActive(false);
        }
        skinPlayer[color].SetActive(true);
        Store.skin = color;
    }
}
