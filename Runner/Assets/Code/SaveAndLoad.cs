using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveAndLoad : MonoBehaviour
{
    string filePath;
    public List<GameObject> buttonsBuySaves = new List<GameObject>(); // Лист сохраненных кнопок
    private void Start()
    {
        filePath = Application.persistentDataPath + "/save.gamesave";
        LoadGame();
        GetComponent<Store>().ActiveButtons();
    }

    // Сохранение
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);

        Save save = new Save();

        save.SaveButtons(buttonsBuySaves);
        bf.Serialize(fs, save);
        fs.Close();
    }

    // Загрузка
    public void LoadGame()
    {
        if (!File.Exists(filePath))
            return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);

        Save save = (Save)bf.Deserialize(fs);
        fs.Close();

      for(int i = 0; i < save.activeData.Count; i++)
        {
            buttonsBuySaves[i].SetActive(save.activeData[i]);
        }
    }

    [System.Serializable]
    public class Save
    {
        public List<bool> activeData = new List<bool>();  
        
        // Запись кнопок в лист
        public void SaveButtons(List<GameObject> buttons)
        {
            foreach(GameObject button in buttons)
            {
                bool isAction = button.activeSelf;
                activeData.Add(isAction);
            }
        }
    }
}
