using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// チャートエディター全体を管理するクラス
/// </summary>
public class ChartEditorManager : MonoBehaviour
{
    private AudioClip m_music;
    public static ChartEditorManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }

    public void SetMusic(AudioClip audioClip)
    {
        m_music = audioClip;
    }
}
