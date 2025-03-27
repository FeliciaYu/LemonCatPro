using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    //TODO：
    //1.判断用户角色是否进入结束区域，如果进入，触发游戏结束的相关操作
    //2.书写游戏结束的逻辑：
    //  2.1 调用结束UI，展示胜利画面（通过更改UI的透明度来实现）
    //  2.2 设置计时器，到指定时间，退出游戏
    //步骤1，应该写入触发器事件
    //步骤2，应该将游戏结束的操作，写入一个自定义的函数
    //在Update中，使用一个开关来判断是否调用2代表的函数
    //而这个开关变量，就是玩家是否已经进入结束区域，在步骤1的触发器事件中赋值。

    //声明一个开关变量，存储用户是否在触发器中
    bool m_IsPlayerAtExit;
    //声明一个公开对象，用来获取用户角色
    public GameObject player;

    //淡入淡出 更改透明度的时间
    public float fadeDuration = 1.0f;
    //计时器
    float m_Timer;
    //正常显示结束UI的时间
    public float displayImageDuration = 1.0f;
    //声明一个CanvasGroup，用来获取UI中的实例来更改UI图像的透明度
    public CanvasGroup exitBackgroundImageCanvasGroup;
    //新增一个表示游戏失败的结束界面ui
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    //用一个bool变量代表玩家是否被敌人抓到
    bool m_IsPlayerCaught;
    //声明声音源对象
    //胜利
    public AudioSource exitAudio;
    //失败
    public AudioSource caughtAudio;
    //播放声音开关
    bool m_HasAudioPlayed;
    //幽灵
    public AudioSource GhostAudio;

    //如果被抓到，设置开关值为真
    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    //触发器事件
    private void OnTriggerEnter(Collider other)
    {
        //如果触发器碰撞的是玩家对象则将开关设置为true
        if(other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //监测触发器有无被触发
        if(m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup,false,exitAudio,GhostAudio);
        }
        //玩家被抓到
        else if(m_IsPlayerCaught)
        {
            //调用结束游戏的方法
            EndLevel(caughtBackgroundImageCanvasGroup,true,caughtAudio,GhostAudio);
        }
        
    }

    //结束当前关卡，当前游戏只有一个scene，相当于结束游戏
    //参数1：结束ui对应的游戏对象
    //参数2：是否重新开始
    //参数3：播放结束声音剪辑的声音源对象
    void EndLevel(CanvasGroup imageCanvasGroup,bool doRestart,AudioSource audioSource,AudioSource ghostAudio)
    {
        //游戏结束时停止播放幽灵声音
        ghostAudio.Stop();
        //如果没有播放过
        if(!m_HasAudioPlayed)
        {
            //播放音频源所挂接的音频剪辑
            audioSource.Play();
            //将bool值设置为真，表示已经播放过
            m_HasAudioPlayed=true;
        }
        //计时器赋值
        //计时器随着Update逐渐增大
        m_Timer += Time.deltaTime;
        //逐渐更改透明度(alpha控制透明度)
        imageCanvasGroup.alpha = m_Timer/fadeDuration;
        
        //当计时器时长大于设定的透明度变化时长同正常显示UI界面时长之和时
        //退出游戏
        if(m_Timer>fadeDuration+displayImageDuration)
        {
            //如果重启游戏为真
            if(doRestart)
            {
                //重新加载当前指定的场景
                SceneManager.LoadScene(0);
            }
            else{
            //退出当前应用程序，打包发布后才能生效
            Application.Quit();
            //编译器状态下停止游戏运行
            //UnityEditor.EditorApplication.isPlaying = false;
            }
        }

    }
}
