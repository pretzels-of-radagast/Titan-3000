using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;

public class ElementPrefabAutomator : MonoBehaviour
{
    /*
    [Header("Prefab Paths")]
    public static string CardPath = "Assets/Prefabs/Cards";
    public static string RendererPath = "Assets/Prefabs/Renderer";
    */

    [Header("Prefab Attributes")]
    public string name;
    public ElementType elementType;
    public Sprite sprite;

    [Header("Bases")]
    public ElementRenderer BaseRenderer;
    public Card BaseCard;

    // eventually want to make this an SO
    public ElementLibrary library;
    
    
    [ContextMenu("Register New Element")]
    public void Create() {
        ElementRenderer elementRenderer = CreateRenderer();
        Card elementCard = CreateCard();

        library.ElementBook.Add(new ElementRegistry(){
            type = elementType,
            renderer = elementRenderer,
            card = elementCard
        });

        EditorUtility.SetDirty(library);
    }


    [ContextMenu("Create Renderer")]
    public ElementRenderer CreateRenderer() {
        try{
            PrefabUtility.UnpackPrefabInstance(BaseRenderer.gameObject, PrefabUnpackMode.Completely, InteractionMode.UserAction);
        } catch {}
        
        Image icon = BaseRenderer.transform.Find("icon").GetComponent<Image>();
        icon.sprite = sprite;
        GameObject go = BaseRenderer.gameObject;

        string localPath = $"Assets/Prefabs/Renderers/{name}Renderer.prefab";;

        // Make sure the file name is unique, in case an existing Prefab has the same name.
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

        // Create the new Prefab and log whether Prefab was saved successfully.
        bool prefabSuccess;
        ElementRenderer elementRenderer = PrefabUtility.SaveAsPrefabAssetAndConnect(go, localPath, InteractionMode.UserAction, out prefabSuccess).GetComponent<ElementRenderer>();

        return elementRenderer;

    }

    [ContextMenu("Create Card")]
    public Card CreateCard() {
        try{
            PrefabUtility.UnpackPrefabInstance(BaseCard.gameObject, PrefabUnpackMode.Completely, InteractionMode.UserAction);
        } catch {}
        
        Image icon = BaseCard.transform.Find("icon").GetComponent<Image>();
        icon.sprite = sprite;

        BaseCard.ElementType = elementType;

        GameObject go = BaseCard.gameObject;

        string localPath = $"Assets/Prefabs/Cards/{name}Card.prefab";;

        // Make sure the file name is unique, in case an existing Prefab has the same name.
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

        // Create the new Prefab and log whether Prefab was saved successfully.
        bool prefabSuccess;
        Card elementCard = PrefabUtility.SaveAsPrefabAssetAndConnect(go, localPath, InteractionMode.UserAction, out prefabSuccess).GetComponent<Card>();

        return elementCard;

    }
}
