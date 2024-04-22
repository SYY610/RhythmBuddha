using UnityEngine;

public class BallMover : MonoBehaviour
{
    private Vector3 direction; // 移动方向
    private float speed; // 移动速度
    public GameObject endpoint_z;

    private void Start()
    {
        endpoint_z = GameObject.Find("TargetBottom (1)");
    }

    void Update()
    {
        // 沿着方向移动圆球
        transform.Translate(direction * speed * Time.deltaTime);
        if (transform.position.z <= endpoint_z.transform.position.z)
        {
            Destroy(gameObject);
        }
    }

    // 设置移动方向
    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }

    // 设置移动速度
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
