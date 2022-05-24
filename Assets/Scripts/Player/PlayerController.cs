using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isActive;

    [SerializeField] private PlayerData playerData;
    [SerializeField] private Camera camera;

    private float threshHold = 550;
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
            _firstXPos = camera.ScreenToViewportPoint(Input.mousePosition).x - transform.position.x / threshHold;

        if (Input.GetMouseButton(0))
        {
            _secondXPos = camera.ScreenToViewportPoint(Input.mousePosition).x;
            _deltaX = (_secondXPos - _firstXPos) * threshHold;
        }
    }

    private void Open()
    {
        isActive = true;
        _rigidbody.isKinematic = false;
    }

    private void Close()
    {
        isActive = false;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = true;
    }
   
}
