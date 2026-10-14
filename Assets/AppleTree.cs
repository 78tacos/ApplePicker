using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public GameObject branchPrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;

    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;

        // About 1 in 10 drops also includes a branch.
        if (Random.value < 0.1f)
        {
            GameObject branch = Instantiate<GameObject>(branchPrefab);
            branch.transform.position = transform.position;
        }

        Invoke("DropApple", appleDropDelay);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }
    void FixedUpdate()
    {
        // FixedUpdate so the turn chance is not tied to frame rate.
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
}
