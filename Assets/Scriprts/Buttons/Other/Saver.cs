using System.IO;
using UnityEngine;
using Lib;

public class Saver : MonoBehaviour
{
    public GameInformation gamedata;
    string dataPath;

    void Start()
    {
        dataPath = Path.Combine(Application.dataPath, "GameData.txt");
    }

    public void Save()
    {
        gamedata = new GameInformation(GameController.tile,
                                       GameController.turn,
                                       GameController.resources,
                                       GameController.income,
                                       GameController.incomebonus,
                                       GameController.firstdecisioneffect,
                                       GameController.beaconisbuilt,
                                       GameController.arkisbuilt,
                                       GameController.attitude);
        SaveGame(gamedata, dataPath);
    }
    public void Load()
    {
        if (!File.Exists(dataPath))
            Debug.Log("No File");
        else
        {
            gamedata = LoadGame(dataPath);
            GameController.GetFromSave(gamedata.tile,
                                       gamedata.turn,
                                       gamedata.resources,
                                       gamedata.income,
                                       gamedata.incomebonus,
                                       gamedata.firstdecisioneffect,
                                       gamedata.beaconisbuilt,
                                       gamedata.arkisbuilt,
                                       gamedata.attitude);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }

    static void SaveGame(GameInformation data, string path)
    {
        string jsonString = JsonUtility.ToJson(data);

        using (StreamWriter streamWriter = File.CreateText(path))
        {
            streamWriter.Write(jsonString);
        }
    }

    static GameInformation LoadGame(string path)
    {
        using (StreamReader streamReader = File.OpenText(path))
        {

            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<GameInformation>(jsonString);
        }
    }
}

[System.Serializable]
public class GameInformation
{
    public GameInformation(Province[] _tile,
                            int _turn,
                            Production _resources,
                            Production _income,
                            Production _incomebonus,
                            bool _firstdecisioneffect,
                            int _beaconisbuilt,
                            bool _arkisbuilt,
                            int _attitude)

    {
        tile = _tile;
        turn = _turn;
        resources = _resources;
        income = _income;
        incomebonus = _incomebonus;
        firstdecisioneffect = _firstdecisioneffect;
        beaconisbuilt = _beaconisbuilt;
        arkisbuilt = _arkisbuilt;
        attitude = _attitude;
    }

    public Province[] tile;
    public int turn;
    public Production resources;
    public Production income;

    public Production incomebonus;

    public bool firstdecisioneffect;
    public int beaconisbuilt;
    public bool arkisbuilt;
    public int attitude;

}

