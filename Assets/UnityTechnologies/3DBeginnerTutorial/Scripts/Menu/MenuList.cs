using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuList : MonoBehaviour
{
    //�˵��б�
    public GameObject menuList;
    //��ȡ���������б�
    public GameObject MusicMenu;
    //����Esc��״̬
    [SerializeField] private bool menuKeys = true;
    //��ȡ������Ч�Ķ���
    [SerializeField] private GameObject GhostSound;
    private AudioSource GsAudioSource;
    //��ȡLemonCat�����������Ч
    [SerializeField] private GameObject LemonCatSound;
    private AudioSource LmAudioSource;
    //��ȡ��������
    [SerializeField] private GameObject BgSound;
    //������������
    [SerializeField] private Slider MusicSlider;
    private AudioSource BGaudioSource;
    //��Ч����
    [SerializeField] private Slider SoundeffectsSlider;

    // Start is called before the first frame update
    void Start()
    {
        //��ȡ�����������
        BGaudioSource = BgSound.GetComponent<AudioSource>();
        //��ȡ������Ч���
        GsAudioSource = GhostSound.GetComponent<AudioSource>();
        //��ȡLemonCat������Ч���
        LmAudioSource = LemonCatSound.GetComponent<AudioSource>();

        //���¼�
        //��������
        MusicSlider.onValueChanged.AddListener(value => OnSliderValueChanged(value, MusicSlider));
       



        
    }

    // Update is called once per frame
    void Update()
    {
        //����Esc�������˵�
        if (menuKeys)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuList.SetActive(true);
                menuKeys = false;
                Time.timeScale = 0;//ʱ����ͣ

            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            menuList.SetActive(false);
            menuKeys = true;
            Time.timeScale = 1;//ʱ��ָ�����
        }
    }

    //������Ϸ
    public void Return() 
    {
        menuList.SetActive(false);
        menuKeys = true;
        Time.timeScale = 1;//ʱ��ָ�����
    }

    //���¿�ʼ��Ϸ
    public void Restart() 
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    //�������˵�
    public void Exit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //���������ý���
    public void MusicOptionsOpen() 
    {
        menuList.SetActive(false);
        MusicMenu.SetActive(true);
    }

    //�ر��������ý���
    public void MusicOptionsClose() 
    {
        menuList.SetActive(true);
        MusicMenu.SetActive(false);
    }

    //ͳһ�ص�����
    private void OnSliderValueChanged(float value, Slider targetSlider) 
    {
        //������������
        if (targetSlider == MusicSlider)
        {
            
        }
        //��Ч����
        else if (targetSlider == SoundeffectsSlider) 
        {

        }

    }

}
