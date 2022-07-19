using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// チャートエディター全体を管理するクラス
/// </summary>
public class ChartEditorManager : MonoBehaviour
{
    private AudioClip m_music;
    private string m_stageName;
    private float m_bpm;
    private float m_offset;
    public static ChartEditorManager Instance { get; private set; }
    public AudioClip SetMusic { set => m_music = value; }
    public string SetStageName { set => m_stageName = value; }
    public float SetBPM { set => m_bpm = value; }
    public float SetOffset { set => m_offset = value; }

    //小節 * 拍子 * 60 / BPM = 長さ
    //小節 = BPM * 長さ / 60 * 拍子

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }
}
