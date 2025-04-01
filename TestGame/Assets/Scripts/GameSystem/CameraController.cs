using UnityEngine;

public class CameraController : MonoBehaviour
{
    public KeyCode panButton = KeyCode.Mouse0; // Кнопка для перемещения (ЛКМ)

    [SerializeField] float movewSpeedCam = 2; // Скорость перемещения камеры
    [SerializeField] Vector2 minXZ = new Vector2(-10f, -10f); // Минимальные границы (XZ)  перемещения
    [SerializeField] Vector2 maxXZ = new Vector2(10f, 10f);   // Максимальные границы (XZ)  перемещения
    [SerializeField] Vector3 lastMousePosition;
    [SerializeField] State state;

    private bool isMoving = false;

    void Update()
    {
        HandleCameraMovement();
    }

    void HandleCameraMovement()
    {
        if (Input.GetKeyDown(panButton))
        {
            isMoving = true;
            lastMousePosition = Input.mousePosition;
     
            if (!state.GetStatMenu())
            {
                state.ChangeStat(State.StatType.Camera);
            }
        }

        if (Input.GetKeyUp(panButton))
        {
            isMoving = false;
     
            if (!state.GetStatMenu())
            {
                state.ChangeStat(State.StatType.Move);
            }
        }

        if (isMoving&& !state.GetStatMenu())
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            Vector3 move = new Vector3(-delta.x, 0, -delta.y) * movewSpeedCam * Time.deltaTime;

            Vector3 newPosition = transform.position + move;
            newPosition.x = Mathf.Clamp(newPosition.x, minXZ.x, maxXZ.x);
            newPosition.z = Mathf.Clamp(newPosition.z, minXZ.y, maxXZ.y);

            transform.position = newPosition;
            lastMousePosition = Input.mousePosition;
        }
    }

    public bool GetStatusMoveCam()
    {
        return isMoving;
    }
}
