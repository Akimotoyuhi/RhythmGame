using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �`���[�g�G�f�B�^�[�S�̂��Ǘ�����N���X
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

    //���� * ���q * 60 / BPM = ����
    //���� = BPM * ���� / 60 * ���q

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }
}
