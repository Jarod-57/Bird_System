using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public RuntimeAnimatorController birdACS;
    public int numberOfBirds = 10;
    public float spawnRadius = 50f;
    public float minHeight = 10f;
    public float maxHeight = 20f;

    void Start()
    {
        for (int i = 0; i < numberOfBirds; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnRadius, spawnRadius),
                Random.Range(minHeight, maxHeight),
                Random.Range(-spawnRadius, spawnRadius)
            );
            spawnPosition += transform.position; 

            GameObject newBird = Instantiate(birdPrefab, spawnPosition, Quaternion.identity, transform);
            SetupBird(newBird);
        }
    }

    void SetupBird(GameObject bird)
    {
        BirdController birdController = bird.GetComponent<BirdController>();
        if (birdController == null)
        {
            birdController = bird.AddComponent<BirdController>();
        }
        birdController.minHeight = minHeight;
        birdController.maxHeight = maxHeight;
        birdController.spawnRadius = spawnRadius;

        Animator birdAnimator = bird.GetComponent<Animator>();
        if (birdAnimator == null)
        {
            birdAnimator = bird.AddComponent<Animator>();
        }
        birdAnimator.runtimeAnimatorController = birdACS;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
