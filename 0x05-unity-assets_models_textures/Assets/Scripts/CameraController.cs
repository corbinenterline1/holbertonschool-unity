using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary> Player's Position </summary>
    public Transform playerBody;

    [SerializeField]
    private float rotationSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        playerBody.Rotate(Vector3.up, mouseInput.x * rotationSpeed);
    }
}