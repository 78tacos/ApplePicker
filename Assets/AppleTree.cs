using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public GameObject branchPrefab; // Add branch prefab
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;
    //public float branchDropDelay = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //apple starting drop
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        // Always drop an apple
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;

        // Randomly drop a branch at 10% rate
        if (Random.value < 0.1f)
        {
            GameObject branch = Instantiate<GameObject>(branchPrefab);
            branch.transform.position = transform.position;
        }

        Invoke("DropApple", appleDropDelay);
    }

    // update is called once per frame
    void Update()
    {
        //movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //direction change
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //move left
        }
        /*else if (Random.value < changeDirChance)
        {
            speed *= -1; //change direction
        }
        */
    }
    void FixedUpdate()
    {
        //random direction change
        if (Random.value < changeDirChance)
        {
            speed *= -1; //change direction
        }
    }
}
