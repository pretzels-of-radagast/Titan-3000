using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] // allows this class to be converted to json
public class SaveDataContainer {

    public SaveData SaveData;

    public SaveDataContainer() {
        SaveData = new SaveData("New Save", new bool[10], CharacterPalette.THE_LEXER, new RunNodeSaveData[]{});
    }

    public SaveDataContainer(SaveData saveData) {
        SaveData = saveData;
    }

    public SaveDataContainer DeepCopy() {
        // translate to and from json to make a deep copy without a billion copy() methods :)
        string json = JsonUtility.ToJson(this);
        SaveDataContainer deepCopy = JsonUtility.FromJson<SaveDataContainer>(json);

        return deepCopy;
    }

    public void AddExerciseObject() {
        return;
    }

}

public enum CharacterPalette {
    THE_LEXER, // DEFAULT
    BUBBLEMGUM, // 40
    NUCLEAR, // 50
    SMOKE, // 60
    CLOUD_9, // 70
    DIMLIGHT, // 80
    ROSE, // 90
    LUNE, // 100
    NEPTUNE, // HIT AVG 110
    GAY // HIT RAW 150
}

public enum RUN_NODE_TAGS {
    // personal
    PERSONAL_BEST,
    GAINED_PALETTE,
    HIT_HUNDRED,
    HIT_HUNDREDFIFTYRAW
}


[System.Serializable]
public class RunNodeSaveData {

    public RunNodeSaveData(string msg, float wpmhi, float wpmavg, int combohi, float comboavg, int wavescleared, int[] specialtags) {
        Message = msg;

        WPMHI = wpmhi;
        WPMAVG = wpmavg;

        ComboHI = combohi;
        ComboAVG = comboavg;

        WavesCleared = wavescleared;

        SpecialTags = specialtags;

    }

    public string Message;

    public float WPMHI;
    public float WPMAVG;

    public int ComboHI;
    public float ComboAVG;

    public int WavesCleared;

    public int[] SpecialTags;
}

[System.Serializable]
public class SaveData {

    public SaveData(string name, bool[] charactersUnlocked, CharacterPalette currentPalette, RunNodeSaveData[] runNodes) {
        UserName = name;
        CharactersUnlocked = charactersUnlocked;
        CurrentPalette = currentPalette;
        RunNodeSaveDatas = runNodes;
    }

    public string UserName;

    public bool[] CharactersUnlocked;

    public CharacterPalette CurrentPalette;

    public RunNodeSaveData[] RunNodeSaveDatas;

    public float TotalWPMHI;

    public override string ToString() {
        return UserName;
    }

    public SaveData copy() {
        return new SaveData(this.UserName, (bool[]) CharactersUnlocked.Clone(), CurrentPalette, RunNodeSaveDatas);
    }
}
