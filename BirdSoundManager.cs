using UnityEngine;
using System.Collections;

public class BirdSoundManager : MonoBehaviour
{
    public GameObject birdPrefab;
    public float soundInterval = 360f; 

    void Start()
    {
        StartCoroutine(PlayBirdSound());
    }

    IEnumerator PlayBirdSound()
    {
        while (true)
        {
            yield return new WaitForSeconds(soundInterval);
            PlaySoundOnRandomBird();
        }
    }

    void PlaySoundOnRandomBird()
    {
        GameObject[] birds = GameObject.FindGameObjectsWithTag("Bird");

        if (birds.Length == 0)
        {
            Debug.LogWarning("No birds found in the scene!");
            return;
        }

        GameObject randomBird = birds[Random.Range(0, birds.Length)];

        AudioSource audioSource = randomBird.GetComponent<AudioSource>();
        if (audioSource != null) audioSource.Play();
        else Debug.LogWarning("No AudioSource found on the selected bird!");
    }
}
