using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0; // 游戏得分

    // 单例模式
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    // 添加得分
    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
        // 在这里您可以将得分显示到UI上，或者执行其他相关的游戏逻辑
    }
}
