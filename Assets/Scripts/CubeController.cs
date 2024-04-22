using System.Collections.Generic;

using UnityEngine;

public class CubeController : MonoBehaviour
{
    public AudioClip collisionSound; // 碰撞时播放的音频
    public Animator muyuAnimator; // Muyu的动画控制器
    public float moveSpeed = 5f; // Cube的移动速度
    public Transform[] muyus;

    void Update()
    {
        // 获取水平输入
        float horizontalInput = Input.GetAxis("Horizontal");

        // 根据水平输入轴的值来移动Cube
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * -moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
    void OnCollisionEnter(Collision collision)
    {
        Transform nearestObject = GetNearestObject();
        if (nearestObject != null)
        {
            // 获取最近物体的 GameObject
            GameObject nearestGameObject = nearestObject.gameObject;
            muyuAnimator = nearestGameObject.GetComponent<Animator>();

        }
        // 如果碰撞物体是圆球
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 播放音频
            AudioSource.PlayClipAtPoint(collisionSound, transform.position);

            // 播放动画
            if (muyuAnimator != null)
            {
                muyuAnimator.SetTrigger("PlayAnimation");
            }

            // 销毁圆球
            Destroy(collision.gameObject);
        }
    }
    Transform GetNearestObject()
    {
        Transform nearestObject = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Transform target in muyus)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestObject = target;
            }
        }

        return nearestObject;
    }

}
