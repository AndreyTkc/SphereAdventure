using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    // Game data structure
    [Serializable]
    public class GameData
    {
        public int completedLevels;
    }

    private static readonly string filePath = Path.Combine(Application.persistentDataPath, "GameData.json");
    private static readonly string encryptionKey = "Gjd38Db2kS47BsP17bE72Z8hAk2hdy9n"; // Must be 16, 24, or 32 chars

    // Save game data
    public static void Save(GameData data)
    {
        try
        {
            // Serialize the data to JSON
            string jsonData = JsonUtility.ToJson(data);

            // Encrypt the JSON
            string encryptedData = Encrypt(jsonData, encryptionKey);

            // Write encrypted data to a file
            File.WriteAllText(filePath, encryptedData);

            Debug.Log("Game data saved successfully!");
            
            Debug.Log(data.completedLevels);
            
            Debug.Log("Persistent Data Path: " + Application.persistentDataPath);
        }
        catch (Exception ex)
        {
            Debug.Log("Error saving game data: " + ex.Message);
        }
    }

    // Load game data
    public static GameData Load()
    {
        try
        {
            // Read the encrypted file
            if (!File.Exists(filePath))
            {
                Debug.LogWarning("No save file found!");
                return null;
            }

            string encryptedData = File.ReadAllText(filePath);

            // Decrypt the data
            string jsonData = Decrypt(encryptedData, encryptionKey);

            // Deserialize JSON back to GameData
            GameData data = JsonUtility.FromJson<GameData>(jsonData);

            Debug.Log("Game data loaded successfully!");
            
            Debug.Log(data.completedLevels);
            
            return data;
        }
        catch (Exception ex)
        {
            Debug.LogError("Error loading game data: " + ex.Message);
            return null;
        }
    }

    // Encrypt a string using AES
    private static string Encrypt(string plainText, string key)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = new byte[16]; // Initialization Vector (set to zeros for simplicity)

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    // Decrypt a string using AES
    private static string Decrypt(string cipherText, string key)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = new byte[16]; // Initialization Vector (must match encryption IV)

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }
}
