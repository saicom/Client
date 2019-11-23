using UnityEngine;
using System.Collections;
using System;
using Tools;
using GameData;
using UnityEngine.UI;
using System.Reflection;

class CTools
{
    private static float s_fMaxAzimuth = 360;
    private static float s_fMaxZenith = 180;
    private static float s_fPIDegree = 180;
    private static DateTime s_BaseTime = new DateTime(1970, 1, 1, 0, 0, 0);

    public static float MaxAzimuth
    {
        get { return s_fMaxAzimuth; }
    }
    public static float MaxZenith
    {
        get { return s_fMaxZenith; }
    }
    public static float PIDegree
    {
        get { return s_fPIDegree; }
    }

    public static void CheckMarkMaxIndex(UInt64 sGUID)
    {
    }

    public static EObjectType GetGUIDType(UInt64 sGUID)
    {
        return (EObjectType)(sGUID >> 48);
    }

    public static void ClearCharArray(char[] aStr, UInt32 un32Size)
    {
        for (UInt32 i = 0; i < un32Size; i++)
        {
            aStr[i] = '\0';
        }
    }

    public static Boolean IfTypeNPC(EObjectType eOT)
    {
        if ((Int32)EObjectType.eObjectType_NPCBegin < (Int32)eOT && (Int32)eOT < (Int32)EObjectType.eObjectType_NPCBegin + (Int32)EConstEnum.eObjLevel1Inter)
        {
            return true;
        }
        return false;
    }

    public static Boolean IfTypeHero(EObjectType eOT)
    {
        if ((Int32)EObjectType.eObjectType_HeroBegin < (Int32)eOT && (Int32)eOT < (Int32)EObjectType.eObjectType_HeroBegin + (Int32)EConstEnum.eObjLevel1Inter)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// ��ȡ��ǰ����ʱ���
    /// </summary>
    /// <returns></returns>
    public static long GetCurrentTimeUnix()
    {
        TimeSpan cha = (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)));
        long t = (long)cha.TotalSeconds;
        return t;
    }

    public static Int64 GetClientUTCSec()
    {
        TimeSpan sTimeSpan = DateTime.UtcNow - s_BaseTime;
        return (Int64)sTimeSpan.TotalSeconds;
    }

    public static Int64 GetClientLocalSec()
    {
        TimeSpan sTimeSpan = DateTime.Now - s_BaseTime;
        return (Int64)sTimeSpan.TotalSeconds;
    }

    public static Int64 GetClientUTCMillisec()
    {
        TimeSpan sTimeSpan = DateTime.UtcNow - s_BaseTime;
        return (Int64)sTimeSpan.TotalMilliseconds;
    }

    public static Int64 GetClientLocalMillisec()
    {
        TimeSpan sTimeSpan = DateTime.Now - s_BaseTime;
        return (Int64)sTimeSpan.TotalMilliseconds;
    }

    public static float GetApproxDist(Vector3 sFromPos, Vector3 sToPos)
    {
        float fApproximatelyDist = 0;
        Vector3 sTempDist = sToPos - sFromPos;
        fApproximatelyDist += Mathf.Abs(sTempDist.x) + Mathf.Abs(sTempDist.y) + Mathf.Abs(sTempDist.z);
        return fApproximatelyDist;
    }

    public static float GetApproxDistXAndZ(Vector3 sFromPos, Vector3 sToPos)
    {
        float fApproximatelyDist = 0;
        Vector3 sTempDist = sToPos - sFromPos;
        fApproximatelyDist += Mathf.Abs(sTempDist.x) + Mathf.Abs(sTempDist.z);
        return fApproximatelyDist;
    }

    //�ַ����Ƿ�Ϊ��Ч�����֣�ֻ�������ģ���ĸ������)
    public static bool CheckName(string text)
    {
        char ch;
        for (int i = 0; i < text.Length; i++)
        {
            ch = text[i];
            if (!((ch >= 0x4e00 && ch <= 0x9fbb) || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9')))
            {
                return false;
            }
        }

        return true;
    }

    //��ȡ��͸�
    private static float HandleSelfFittingAlongAxis(int axis, GameObject obj)
    {
        ContentSizeFitter.FitMode fitting = (axis == 0 ? obj.GetComponent<ContentSizeFitter>().horizontalFit : obj.GetComponent<ContentSizeFitter>().verticalFit);
        if (fitting == ContentSizeFitter.FitMode.MinSize)
        {
            return LayoutUtility.GetMinSize(obj.GetComponent<RectTransform>(), axis);
        }
        else
        {
            return LayoutUtility.GetPreferredSize(obj.GetComponent<RectTransform>(), axis);
        }
    }

    //������ȡContentSizeFitter������
    public static Vector2 GetPreferredSize(GameObject obj)
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(obj.GetComponent<RectTransform>());
        return new Vector2(HandleSelfFittingAlongAxis(0, obj), HandleSelfFittingAlongAxis(1, obj));
    }

    //ɾ�����ڵ��µ��ӽڵ�
    public static void DeleteChilds(Transform parent, bool deleteAll = true)
    {
        if (deleteAll)
        {
            for (int i = parent.childCount - 1; i >= 0; --i)
            {
                var child = parent.GetChild(i).gameObject;
                GameObject.Destroy(child);
            }
        }
        else
        {
            GameObject.Destroy(parent.GetChild(0).gameObject);
        }
    }

    static public ObjectId GetObjectId(Transform trans)
    {
        ObjectId com = trans.GetComponent<ObjectId>();
        if (com == null)
        {
            return trans.gameObject.AddComponent<ObjectId>();
        }

        return com;
    }

}