using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.back, Space.World);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
