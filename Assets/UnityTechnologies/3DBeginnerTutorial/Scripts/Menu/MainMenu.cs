using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    //��ȡAudio Source���
    [SerializeField] 
    public AudioSource MusicSound;

    //��ȡ�ı����
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
        //�˳���ǰӦ�ó��򣬴�������������Ч
        //Application.Quit();
        //������״̬��ֹͣ��Ϸ����
        UnityEditor.EditorApplication.isPlaying = false;
    }

    //����������������
    //������value�ı䣬BGSound��Voumeֵ
    public void OnSliderValueChanged(float value)
    {
        MusicSound.volume = value;
        MusicSoundText.text = (value * 100).ToString("0");
    }

}
