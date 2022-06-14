using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

public class ProgressLoader<T>
{
    private T data;
    private const string savePath = "/Data/";
    private string path;
    private BinaryFormatter formatter;


    public T Data
    {
        get { return data; }
    }

    private ProgressLoader()
    {

    }

    public ProgressLoader(T defaults)
    {
        formatter = new BinaryFormatter();
        path = Application.persistentDataPath + savePath + "Save" + defaults.GetType().Name + ".dat";
    }

    public void Save()
    {
        if(!Directory.Exists(Application.persistentDataPath + savePath))
        {
            Directory.CreateDirectory(Application.persistentDataPath + savePath);
        }
        var stream = File.Open(path, FileMode.OpenOrCreate);
        try
        {
            formatter.Serialize(stream, data);
        }
        catch (System.Exception e)
        {
            Debug.Log("WARNING " + e.Message);
        }
        finally
        {
            stream.Dispose();
        }
    }

    private void Load(T defaults)
    {
        if(File.Exists(path))
        {
            var stream = File.OpenRead(path);
            data = (T)formatter.Deserialize(stream);
            stream.Dispose();
        }
        else
        {
            data = defaults;
        }
    }

}
public class ProgressDeleter
{
#if UNITY_EDITOR
    [MenuItem("Assets/Delete progress", priority = 2, validate = false)]
#endif
    public static void DeleteData()
    {
        if (Directory.Exists(Application.persistentDataPath + "/Data/"))
        {
            Directory.Delete(Application.persistentDataPath + "/Data/", true);
        }
    }
}
