using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class JsonSaver // this class has no need for MonoBehaviour
{

    public static void Save(System.Object data, string filePath) {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
    }

    public static void SaveEncrypted(System.Object data, string filePath) {
        string json = JsonUtility.ToJson(data);

        AESEncoder crypto = new AESEncoder();
        byte[] soup = crypto.Encrypt(json, "mewhenicantfindthekeyomoriDcolon");

        File.WriteAllBytes(filePath, soup);
    }

    public static SaveDataContainer Load(string filePath) {
        if (File.Exists(filePath)) {
            try {
                string json = File.ReadAllText(filePath);
                return JsonUtility.FromJson<SaveDataContainer>(json);

                // Debug.Log(crypto.Decrypt(json, "mewhenicantfindthekeyomoriDcolon"));

            } catch {
                Debug.LogError($"Unable to load {filePath} please move or delete this file.");
                return null;
            }            
        } else {
            Debug.LogError($"Save file not found: {filePath}");
            return null;
        }
    }

    public static SaveDataContainer LoadEncrypted(string filePath) {
        if (File.Exists(filePath)) {
            try {
                byte[] soup = File.ReadAllBytes(filePath);

                AESEncoder crypto = new AESEncoder();
                string json = crypto.Decrypt(soup, "mewhenicantfindthekeyomoriDcolon");

                return JsonUtility.FromJson<SaveDataContainer>(json);

                // Debug.Log(crypto.Decrypt(json, "mewhenicantfindthekeyomoriDcolon"));

            } catch {
                Debug.LogError($"Unable to load {filePath} please move or delete this file.");
                return null;
            }            
        } else {
            Debug.LogError($"Save file not found: {filePath}");
            return null;
        }
    }

    public static bool IsFileNameFormatValid(string filename) { return filename.IndexOfAny(Path.GetInvalidFileNameChars()) == -1; }

    public static bool FileExists(string path) { return File.Exists(path); }
    public static void CreateFile(string path) { File.Create(path); }
    
    public static bool DirectoryExists(string path) { return Directory.Exists(path); }
    public static void CreateDirectory(string path) { Directory.CreateDirectory(path); }
}
