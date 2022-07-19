using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

/// <summary>
/// ���^�f�[�^�ݒ�N���X
/// </summary>
[System.Serializable]
public class MetaSetting
{
    [SerializeField] Button m_musicSelectButton;
    [SerializeField] Text m_musicName;
    [SerializeField] InputField m_stageName;
    [SerializeField] InputField m_bpm;
    [SerializeField] InputField m_offset;

    public void Setup()
    {
        //���y�t�@�C���̓Ǎ�
        m_musicSelectButton.onClick.AddListener(() => MusicSelect());

        //�X�e�[�W������
        m_stageName.onSubmit.AddListener(s => ChartEditorManager.Instance.SetStageName = s);

        //BPM����
        m_bpm.onSubmit.AddListener(s => ChartEditorManager.Instance.SetBPM = float.Parse(s));

        //���z�{����
        m_offset.onSubmit.AddListener(s => ChartEditorManager.Instance.SetOffset = float.Parse(s));
    }

    private void MusicSelect()
    {
        string path = UnityEditor.EditorUtility.OpenFilePanelWithFilters("���y��I��",
                Application.dataPath,
                new string[]
                {
                    "Audio files", "mp3,wav"
                });
        Debug.Log(path);

        try
        {
            //����Ă����t�@�C���p�X����AudiocClip������Ă���
            AudioClip chip = UnityEditor.AssetDatabase.LoadAssetAtPath<AudioClip>(path.Substring(path.IndexOf("Assets")));
            ChartEditorManager.Instance.SetMusic = chip;
            m_musicName.text = chip.name;
        }
        catch
        {
            Debug.LogError("�����Ȍ`���̃t�@�C���p�X�ł�");
        }
    }
}
