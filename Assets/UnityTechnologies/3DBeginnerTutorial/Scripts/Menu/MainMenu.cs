using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    //获取Audio Source组件
    [SerializeField] 
    public AudioSource MusicSound;

    //获取文本组件
    [SerializeField]
    public TextMeshProUGUI MusicSoundText;

    //StartButton
    public void start()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //EndButton
    public void End()
    {
        //退出当前应用程序，打包发布后才能生效
        //Application.Quit();
        //编译器状态下停止游戏运行
        UnityEditor.EditorApplication.isPlaying = false;
    }

    //拉条控制音乐音量
    //拉条的value改变，BGSound的Voume值
    public void OnSliderValueChanged(float value)
    {
        MusicSound.volume = value;
        MusicSoundText.text = (value * 100).ToString("0");
    }

}
