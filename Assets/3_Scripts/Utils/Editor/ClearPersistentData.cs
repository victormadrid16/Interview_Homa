using System.IO;
using UnityEditor;
using UnityEngine;

public class ClearPersistentData 
{
    [MenuItem("Tools/ClearAllData")]
    private static void ClearAllData()
    {
        PlayerPrefs.DeleteAll();
        string path = Application.persistentDataPath;

        try
        {
            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                File.Delete(file);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to clear persistent data: {e.Message}");
        }
    }
}