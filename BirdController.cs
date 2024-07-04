using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float speed = 15f;
    public float turnSpeed = 2f;
    public float minHeight;
    public float maxHeight;
    public float spawnRadius;
    private Vector3 targetPosition;
    private Transform spawnCenter;

    void Start()
    {
        spawnCenter = transform.parent; 
        SetNewTargetPosition();
    }

    void Update()
    {
        FlyTowardsTarget();
    }

    void SetNewTargetPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;
        randomDirection.y = Random.Range(minHeight, maxHeight); 
        targetPosition = spawnCenter.position + randomDirection;
    }

    void FlyTowardsTarget()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 1f) SetNewTargetPosition();
    }
}
