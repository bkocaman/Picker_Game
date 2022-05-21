using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    [SerializeField] private float swiper;

    [SerializeField] private Camera camera;
    public bool isActive;
    private float _deltaX, _firstXPos, _secondXPos;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Close();
    }

    private void Start()
    {
        EventManager.Instance.OnPlay += Open;
        EventManager.Instance.OnStop += Close;
        EventManager.Instance.OnContinue += Open;
        EventManager.Instance.OnFail += Close;
    }

    private void Update()
    {
        InputGetPos();
    }

    private void FixedUpdate()
    {
        MoveForward();
        MoveHorizontal();
    }

    private void MoveForward()
    {
        if (!isActive) return;
        _rigidbody.velocity = Vector3.forward * playerData.speed;
    }

    private void MoveHorizontal()
    {
        if (!isActive) return;
        _rigidbody.AddForce(Vector3.right * _deltaX, ForceMode.VelocityChange);
        _firstXPos = _secondXPos;
    }

    private void InputGetPos()
    {
        if (Input.GetMouseButtonDown(0))
            _firstXPos = camera.ScreenToViewportPoint(Input.mousePosition).x - transform.position.x / swiper;

        if (Input.GetMouseButton(0))
        {
            _secondXPos = camera.ScreenToViewportPoint(Input.mousePosition).x;
            _deltaX = (_secondXPos - _firstXPos) * swiper;
        }
    }

    private void Open()
    {
        isActive = true;
    }

    private void Close()
    {
        _rigidbody.velocity = Vector3.zero;
        isActive = false;
    }
}