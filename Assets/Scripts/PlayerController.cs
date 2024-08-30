using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float xRange = 5f;

    private float moveDirection = 0f;

    private void Update()
    {
        // Перевірка для руху клавіатурою або кнопками
        if (Input.GetAxis("Horizontal") != 0)
        {
            moveDirection = Input.GetAxis("Horizontal");
        }

        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime * Vector3.right;

        newPosition.x = Mathf.Clamp(newPosition.x, -xRange, xRange);

        transform.position = newPosition;
    }

    public void MoveLeft(bool isPressed)
    {
        if (isPressed)
            moveDirection = -1f;
        else
            moveDirection = 0f;
    }

    public void MoveRight(bool isPressed)
    {
        if (isPressed)
            moveDirection = 1f;
        else
            moveDirection = 0f;
    }
}
