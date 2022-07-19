using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UniRx;
using Cysharp.Threading.Tasks;

public class ChartEditorGuiManager : MonoBehaviour
{
    [SerializeField, Header("メタデータ設定項目")] MetaSetting m_metaSetting;

    private void Start()
    {
        m_metaSetting.Setup();
    }
}
