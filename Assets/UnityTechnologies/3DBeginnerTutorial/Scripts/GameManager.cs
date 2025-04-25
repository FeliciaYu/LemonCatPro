using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //单例模式
    public static GameManager Instance;
    //表示游戏状态
    public GameState State;

    private void Awake()
    {
        //单例模式，确保游戏中的GameManager只有一个实例存在，并在场景切换时不被销毁
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //更新游戏状态
    public void UpdateGameState(GameState newState)
    {
        //更新游戏的当前状态
        State = newState;

        //状态跳转
        switch (newState)
        { 
            //暂停菜单（局内，得有个暂停的按钮
            case GameState.StopMenu:
                break;
            //胜利状态
            case GameState.Victory:
                break;
            //失败状态（被捕状态）
            case GameState.Lose:
                break;
        }
    }
    //枚举类，表示游戏状态
    public enum GameState 
    {
        //暂停菜单（局内，得有个暂停的按钮）
        StopMenu,
        //胜利状态
        Victory,
        //失败状态（被捕状态）
        Lose
    }
}
