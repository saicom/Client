using System;
using UnityEngine;

/// <summary>
/// 游戏配置辅助器。
/// </summary>
public static class SettingHelper
{
    /// <summary>
    /// 加载游戏配置。
    /// </summary>
    /// <returns>是否加载游戏配置成功。</returns>
    public static bool Load()
    {
        return true;
    }

    /// <summary>
    /// 保存游戏配置。
    /// </summary>
    /// <returns>是否保存游戏配置成功。</returns>
    public static bool Save()
    {
        PlayerPrefs.Save();
        return true;
    }

    /// <summary>
    /// 检查是否存在指定游戏配置项。
    /// </summary>
    /// <param name="settingName">要检查游戏配置项的名称。</param>
    /// <returns>指定的游戏配置项是否存在。</returns>
    public static bool HasSetting(string settingName)
    {
        return PlayerPrefs.HasKey(settingName);
    }

    /// <summary>
    /// 移除指定游戏配置项。
    /// </summary>
    /// <param name="settingName">要移除游戏配置项的名称。</param>
    public static void RemoveSetting(string settingName)
    {
        PlayerPrefs.DeleteKey(settingName);
    }

    /// <summary>
    /// 清空所有游戏配置项。
    /// </summary>
    public static void RemoveAllSettings()
    {
        PlayerPrefs.DeleteAll();
    }

    /// <summary>
    /// 从指定游戏配置项中读取布尔值。
    /// </summary>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <returns>读取的布尔值。</returns>
    public static bool GetBool(string settingName)
    {
        return PlayerPrefs.GetInt(settingName) != 0;
    }

    /// <summary>
    /// 从指定游戏配置项中读取布尔值。
    /// </summary>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <param name="defaultValue">当指定的游戏配置项不存在时，返回此默认值。</param>
    /// <returns>读取的布尔值。</returns>
    public static bool GetBool(string settingName, bool defaultValue)
    {
        return PlayerPrefs.GetInt(settingName, defaultValue ? 1 : 0) != 0;
    }

    /// <summary>
    /// 向指定游戏配置项写入布尔值。
    /// </summary>
    /// <param name="settingName">要写入游戏配置项的名称。</param>
    /// <param name="value">要写入的布尔值。</param>
    public static void SetBool(string settingName, bool value)
    {
        PlayerPrefs.SetInt(settingName, value ? 1 : 0);
    }

    /// <summary>
    /// 从指定游戏配置项中读取整数值。
    /// </summary>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <returns>读取的整数值。</returns>
    public static int GetInt(string settingName)
    {
        return PlayerPrefs.GetInt(settingName);
    }

    /// <summary>
    /// 从指定游戏配置项中读取整数值。
    /// </summary>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <param name="defaultValue">当指定的游戏配置项不存在时，返回此默认值。</param>
    /// <returns>读取的整数值。</returns>
    public static int GetInt(string settingName, int defaultValue)
    {
        return PlayerPrefs.GetInt(settingName, defaultValue);
    }

    /// <summary>
    /// 向指定游戏配置项写入整数值。
    /// </summary>
    /// <param name="settingName">要写入游戏配置项的名称。</param>
    /// <param name="value">要写入的整数值。</param>
    public static void SetInt(string settingName, int value)
    {
        PlayerPrefs.SetInt(settingName, value);
    }

    /// <summary>
    /// 从指定游戏配置项中读取浮点数值。
    /// </summary>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <returns>读取的浮点数值。</returns>
    public static float GetFloat(string settingName)
    {
        return PlayerPrefs.GetFloat(settingName);
    }

    /// <summary>
    /// 从指定游戏配置项中读取浮点数值。
    /// </summary>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <param name="defaultValue">当指定的游戏配置项不存在时，返回此默认值。</param>
    /// <returns>读取的浮点数值。</returns>
    public static float GetFloat(string settingName, float defaultValue)
    {
        return PlayerPrefs.GetFloat(settingName, defaultValue);
    }

    /// <summary>
    /// 向指定游戏配置项写入浮点数值。
    /// </summary>
    /// <param name="settingName">要写入游戏配置项的名称。</param>
    /// <param name="value">要写入的浮点数值。</param>
    public static void SetFloat(string settingName, float value)
    {
        PlayerPrefs.SetFloat(settingName, value);
    }

    /// <summary>
    /// 从指定游戏配置项中读取字符串值。
    /// </summary>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <returns>读取的字符串值。</returns>
    public static string GetString(string settingName)
    {
        return PlayerPrefs.GetString(settingName);
    }

    /// <summary>
    /// 从指定游戏配置项中读取字符串值。
    /// </summary>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <param name="defaultValue">当指定的游戏配置项不存在时，返回此默认值。</param>
    /// <returns>读取的字符串值。</returns>
    public static string GetString(string settingName, string defaultValue)
    {
        return PlayerPrefs.GetString(settingName, defaultValue);
    }

    /// <summary>
    /// 向指定游戏配置项写入字符串值。
    /// </summary>
    /// <param name="settingName">要写入游戏配置项的名称。</param>
    /// <param name="value">要写入的字符串值。</param>
    public static void SetString(string settingName, string value)
    {
        PlayerPrefs.SetString(settingName, value);
    }

    /// <summary>
    /// 从指定游戏配置项中读取对象。
    /// </summary>
    /// <typeparam name="T">要读取对象的类型。</typeparam>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <returns>读取的对象。</returns>
    public static T GetObject<T>(string settingName)
    {
        return JsonUtility.FromJson<T>(PlayerPrefs.GetString(settingName));
    }

    /// <summary>
    /// 从指定游戏配置项中读取对象。
    /// </summary>
    /// <param name="objectType">要读取对象的类型。</param>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <returns>读取的对象。</returns>
    public static object GetObject(Type objectType, string settingName)
    {
        return JsonUtility.FromJson(PlayerPrefs.GetString(settingName), objectType);
    }

    /// <summary>
    /// 从指定游戏配置项中读取对象。
    /// </summary>
    /// <typeparam name="T">要读取对象的类型。</typeparam>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <param name="defaultObj">当指定的游戏配置项不存在时，返回此默认对象。</param>
    /// <returns>读取的对象。</returns>
    public static T GetObject<T>(string settingName, T defaultObj)
    {
        string json = PlayerPrefs.GetString(settingName, null);
        if (json == null)
        {
            return defaultObj;
        }

        return JsonUtility.FromJson<T>(json);
    }

    /// <summary>
    /// 从指定游戏配置项中读取对象。
    /// </summary>
    /// <param name="objectType">要读取对象的类型。</param>
    /// <param name="settingName">要获取游戏配置项的名称。</param>
    /// <param name="defaultObj">当指定的游戏配置项不存在时，返回此默认对象。</param>
    /// <returns>读取的对象。</returns>
    public static object GetObject(Type objectType, string settingName, object defaultObj)
    {
        string json = PlayerPrefs.GetString(settingName, null);
        if (json == null)
        {
            return defaultObj;
        }

        return JsonUtility.FromJson(json, objectType);
    }

    /// <summary>
    /// 向指定游戏配置项写入对象。
    /// </summary>
    /// <typeparam name="T">要写入对象的类型。</typeparam>
    /// <param name="settingName">要写入游戏配置项的名称。</param>
    /// <param name="obj">要写入的对象。</param>
    public static void SetObject<T>(string settingName, T obj)
    {
        PlayerPrefs.SetString(settingName, JsonUtility.ToJson(obj));
    }

    /// <summary>
    /// 向指定游戏配置项写入对象。
    /// </summary>
    /// <param name="settingName">要写入游戏配置项的名称。</param>
    /// <param name="obj">要写入的对象。</param>
    public static void SetObject(string settingName, object obj)
    {
        PlayerPrefs.SetString(settingName, JsonUtility.ToJson(obj));
    }
}
