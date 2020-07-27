using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 声音管理类
/// </summary>
public class AudioManger : MonoBehaviour
{
    public static AudioManger Instance;//单例
    public AudioSource BgmAudioSource;//背景音乐
    public AudioSource SeAudioSource;//音效
    private AudioClip _clip;//音乐文件
    /// <summary>
    /// 初始化
    /// </summary>
    void Start()
    {
        Instance = this;
    }
    void Update()
    {
        
    }
    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="Inname"></param>
    public void PlayBgm(string Inname)
    {
        _clip = Resources.Load<AudioClip>(Inname);//加载音乐文件
        BgmAudioSource.clip = _clip;
        BgmAudioSource.Play();
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="Inname"></param>
    public void PlaySe(string Inname)
    {
        _clip = Resources.Load<AudioClip>(Inname);//加载音乐文件
        SeAudioSource.PlayOneShot(_clip);
    }
    /// <summary>
    ///停止背景音乐 
    /// </summary>
    public void StopBgm()
    {
        BgmAudioSource.Stop();
    }
}
