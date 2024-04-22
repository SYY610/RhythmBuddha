using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform[] spawnPoints;
    public Transform[] tracks; // 轨道终点
    public float moveSpeed = 5f; //圆球移动速度
    public float spawnInterval = 1.0f; // 圆球生成间隔
    public float delayBeforeStart = 0f; // 游戏开始后等待的时间
    void Start()
    {
        InvokeRepeating("GenerateBall", delayBeforeStart, spawnInterval);
    }

    void GenerateBall()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length); // 随机选择一个起始点
        Vector3 spawnPosition = spawnPoints[randomIndex].position; // 圆球生成位置

        GameObject ball = Instantiate(ballPrefab, spawnPosition, Quaternion.identity); // 生成圆球

        // 计算轨道方向
        Vector3 direction = tracks[randomIndex].position - spawnPosition;
        direction.Normalize();

        // 将圆球沿着轨道方向移动
        BallMover ballMover = ball.GetComponent<BallMover>();
        if (ballMover != null)
        {
            ballMover.SetDirection(direction);
            ballMover.SetSpeed(moveSpeed);
        }
    }
}
