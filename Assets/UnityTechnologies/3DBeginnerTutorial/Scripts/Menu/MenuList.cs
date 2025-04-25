using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuList : MonoBehaviour
{
    //菜单列表
    public GameObject menuList;
    //获取控制音乐列表
    public GameObject MusicMenu;
    //控制Esc的状态
    [SerializeField] private bool menuKeys = true;
    //获取幽灵音效的对象
    [SerializeField] private GameObject GhostSound;
    private AudioSource GsAudioSource;
    //获取LemonCat对象包含的音效
    [SerializeField] private GameObject LemonCatSound;
    private AudioSource LmAudioSource;
    //获取背景音乐
    [SerializeField] private GameObject BgSound;
    //音乐音量拉条
    [SerializeField] private Slider MusicSlider;
    private AudioSource BGaudioSource;
    //音效拉条
    [SerializeField] private Slider SoundeffectsSlider;

    // Start is called before the first frame update
    void Start()
    {
        //获取背景音乐组件
        BGaudioSource = BgSound.GetComponent<AudioSource>();
        //获取幽灵音效组件
        GsAudioSource = GhostSound.GetComponent<AudioSource>();
        //获取LemonCat对象音效组件
        LmAudioSource = LemonCatSound.GetComponent<AudioSource>();

        //绑定事件
        //背景音乐
        MusicSlider.onValueChanged.AddListener(value => OnSliderValueChanged(value, MusicSlider));
       



        
    }

    // Update is called once per frame
    void Update()
    {
        //输入Esc键触发菜单
        if (menuKeys)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuList.SetActive(true);
                menuKeys = false;
                Time.timeScale = 0;//时间暂停

            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            menuList.SetActive(false);
            menuKeys = true;
            Time.timeScale = 1;//时间恢复正常
        }
    }

    //返回游戏
    public void Return() 
    {
        menuList.SetActive(false);
        menuKeys = true;
        Time.timeScale = 1;//时间恢复正常
    }

    //重新开始游戏
    public void Restart() 
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    //返回主菜单
    public void Exit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //打开音乐设置界面
    public void MusicOptionsOpen() 
    {
        menuList.SetActive(false);
        MusicMenu.SetActive(true);
    }

    //关闭音乐设置界面
    public void MusicOptionsClose() 
    {
        menuList.SetActive(true);
        MusicMenu.SetActive(false);
    }

    //统一回调函数
    private void OnSliderValueChanged(float value, Slider targetSlider) 
    {
        //背景音乐拉条
        if (targetSlider == MusicSlider)
        {
            
        }
        //音效拉条
        else if (targetSlider == SoundeffectsSlider) 
        {

        }

    }

}
