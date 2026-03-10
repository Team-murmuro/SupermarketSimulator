using System.IO;
using UnityEditor;
using UnityEngine;
using Utils.ClassUtility;

// Item ScriptableObject 자동 생성기
public class ItemSOGenerator
{
    private const string dataPath = "Assets/Resources/JSON/Items.json";
    private const string OutputPath = "Assets/08.ScriptableObjects/Item/";

    [MenuItem("Tools/GenerateItemsSO")]
    public static void Generate()
    {
        // 만약 출력 폴더가 존재하지 않으면 생성
        if (!Directory.Exists(OutputPath))
            Directory.CreateDirectory(OutputPath);

        // JSON 파일을 문자열로 읽어옴
        string data = File.ReadAllText(dataPath);
        // JSON 문자열을 ItemDataList 객체로 역직렬화
        ItemList dataList = JsonUtility.FromJson<ItemList>(data);

        var spriteMap = ItemSpriteCache.Build();

        foreach (var _data in dataList.Items)
        {
            // key 없을 경우 에러 처리
            if (!spriteMap.ContainsKey(_data.iconKey))
            {
                throw new System.Exception(
                    $"아이템 ID {_data.id} - Sprite 키 없음: {_data.iconKey}"
                );
            }

            // SpriteMap에서 iconKey에 해당하는 Sprite 가져오기
            if (!spriteMap.TryGetValue(_data.iconKey, out Sprite icon))
            {
                Debug.LogError($"[ItemSOGenerator] Sprite 없음: {_data.iconKey}");
                continue;
            }

            // ItemSO 타입의 ScriptableObject 인스턴스 생성
            ItemSO so = ScriptableObject.CreateInstance<ItemSO>();

            so.id = _data.id;
            so.itmeImage = icon;
            so.itemEName = _data.itemEName;
            so.itemKName = _data.itemKName;
            so.price = _data.price;
            so.packageQuantity = _data.packageQuantity;
            so.categoryType = _data.categoryType;
            so.category = _data.category;

            string assetPath = $"{OutputPath}Item_{_data.itemEName}.asset";
            // ScriptableObject를 실제 에셋 파일로 생성
            AssetDatabase.CreateAsset(so, assetPath);
        }

        // 생성된 모든 에셋을 디스크에 저장
        AssetDatabase.SaveAssets();
        // 에디터 에셋 목록 갱신
        AssetDatabase.Refresh();
    }
}