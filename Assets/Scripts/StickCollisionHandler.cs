using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickCollisionHandler : MonoBehaviour
{
    // 声明一个公共变量用于存储目标对象的 Animation 组件的引用
    public Animation targetAni;

    // 在碰撞事件中触发目标对象的动画
    private void OnTriggerEnter(Collider other)
    {
        // 检查碰撞对象是否为木棍（Stick）
        if (other.CompareTag("Stick"))
        {
            // 播放目标对象的动画
            targetAni.Play();
        }
    }
}
