using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

[System.Serializable]
public class MetaSetting
{
    [SerializeField] Button m_musicSelectButton;
    [SerializeField] Text m_musicNameText;

    public void Setup()
    {
        m_musicSelectButton.onClick.AddListener(() =>
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
                ChartEditorManager.Instance.SetMusic(chip);
                m_musicNameText.text = chip.name;
            }
            catch
            {
                Debug.LogError("無効な形式のファイルパスです");
            }
        });
    }
}
