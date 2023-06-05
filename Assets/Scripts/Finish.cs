using UnityEngine;

public class Finish : MonoBehaviour
{
    public Transform finishMessageSpawnPoint;
    public GameObject finishMessagePrefab;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject finishmessage = Instantiate(finishMessagePrefab, finishMessageSpawnPoint.position, Quaternion.identity);
        }
    }

}