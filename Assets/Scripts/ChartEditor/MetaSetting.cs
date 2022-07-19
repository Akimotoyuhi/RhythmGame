using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

/// <summary>
/// メタデータ設定クラス
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
        //音楽ファイルの読込
        m_musicSelectButton.onClick.AddListener(() => MusicSelect());

        //ステージ名決め
        m_stageName.onSubmit.AddListener(s => ChartEditorManager.Instance.SetStageName = s);

        //BPM決め
        m_bpm.onSubmit.AddListener(s => ChartEditorManager.Instance.SetBPM = float.Parse(s));

        //お布施決め
        m_offset.onSubmit.AddListener(s => ChartEditorManager.Instance.SetOffset = float.Parse(s));
    }

    private void MusicSelect()
    {
        string path = UnityEditor.EditorUtility.OpenFilePanelWithFilters("音楽を選択",
                Application.dataPath,
                new string[]
                {
                    "Audio files", "mp3,wav"
                });
        Debug.Log(path);

        try
        {
            //取ってきたファイルパスからAudiocClipを取ってくる
            AudioClip chip = UnityEditor.AssetDatabase.LoadAssetAtPath<AudioClip>(path.Substring(path.IndexOf("Assets")));
            ChartEditorManager.Instance.SetMusic = chip;
            m_musicName.text = chip.name;
        }
        catch
        {
            Debug.LogError("無効な形式のファイルパスです");
        }
    }
}
