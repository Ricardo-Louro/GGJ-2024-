using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private static bool activeChaser = false;

    [SerializeField] private GameObject[] chasers;

    [SerializeField] private Transform bottomLeft;
    [SerializeField] private Transform topRight;
    [SerializeField] private Transform roadLeft;
    [SerializeField] private Transform roadRight;

    [SerializeField] private float height;

    private float bottomEdge;
    private float topEdge;
    private float leftEdge;
    private float rightEdge;

    private float roadLeftEdge;
    private float roadRightEdge;

    // Start is called before the first frame update
    void Start()
    {
        if(!activeChaser)
        {
            CalculateEdges();

            GameObject chaser = Instantiate(chasers[Random.Range(0, chasers.Length)]);
            chaser.transform.position = ChooseSpawn();
        }
    }

    private Vector3 ChooseSpawn()
    {
        float chosen_side;

        float left_side = Random.Range(leftEdge, roadLeftEdge);
        float right_side = Random.Range(roadRightEdge, rightEdge);

        if(Random.value > 0.5)
        {
            chosen_side = left_side;
        }
        else
        {
            chosen_side = right_side;
        }

        Vector3 spawnPos = new Vector3(chosen_side, height, Random.Range(bottomEdge, topEdge));

        return spawnPos;
    }

    private void CalculateEdges()
    {
        topEdge = topRight.position.z;
        bottomEdge = bottomLeft.position.z;

        leftEdge = bottomLeft.position.x;
        topEdge = topRight.position.x;

        roadLeftEdge = roadLeft.position.x;
        roadRightEdge = roadRight.position.x;
    }

    public void QueueSpawn()
    {
        activeChaser = false;
    }
}
