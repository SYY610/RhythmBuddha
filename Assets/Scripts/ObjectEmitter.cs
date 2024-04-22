using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEmitter : MonoBehaviour
{
    public GameObject noteObjectPrefab; // NoteObject 预制体
    public float emissionRate = 1f; // 每秒发射的速率
    public float noteSpeed = 5f; // NoteObject 的速度

    private float timer; // 计时器

    void Update()
    {
        // 根据发射速率触发发射逻辑
        timer += Time.deltaTime;
        if (timer >= 1f / emissionRate)
        {
            EmitNoteObject();
            timer = 0f;
        }
    }

    void EmitNoteObject()
    {
        // 实例化 NoteObject 预制体
        GameObject newNoteObject = Instantiate(noteObjectPrefab, transform.position, Quaternion.identity);

        // 获取刚体组件，并设置速度使其沿着 -z 轴方向移动
        Rigidbody rb = newNoteObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = -transform.forward * noteSpeed;
        }
    }

    // 可以根据需要添加检测到达目标物体的逻辑
    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Target"))
    //     {
    //         // 到达目标物体时的操作
    //     }
    // }
}
