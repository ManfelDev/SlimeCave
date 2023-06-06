using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 5f;
    public float rotationSpeed = 5f;

    private Vector3 startPosition;
    private float direction = 1f;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x - startPosition.x) > distance)
        {
            direction *= -1f;
        }

        Quaternion targetRotation = Quaternion.Euler(0f, direction == 1f ? 0f : 180f, 0f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}