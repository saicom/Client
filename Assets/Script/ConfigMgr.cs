using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

//loader start

public class ItemCfg {
	public Int32	m_Id;	//编号
	public string	m_Name;	//名称
	public string	m_Note;	//描述
	public Int32	m_Type;	//类型
	public Int32	m_Linkid;	//使用后关联ID
	public Int32	m_Warehousetype;	//仓库类型
	public Int32	m_Quality;	//物品品质
	public string	m_Icon;	//图标路径
	public string	m_Tag;	//角标路径
	public Int32	m_Pile;	//堆叠数量
	public Int32	m_Usetype;	//使用类型
	public Int32	m_Bundleuse;	//是否可批量使用
	public List<Int32>	m_Sellvalue;	//出售价格
	public List<Int32>	m_Convertvalue;	//转化价值
	public double	m_Coefficient;	//倍数
	public double	m_Timelimit;	//使用时间限制
	public Int32	m_Usetimeslimit;	//使用次数限制
	public Int32	m_Levellimit;	//关卡限制


	public void SetId(Int32 v) {
        m_Id = v;
    }

	public void SetName(string v) {
        m_Name = v;
    }

	public void SetNote(string v) {
        m_Note = v;
    }

	public void SetType(Int32 v) {
        m_Type = v;
    }

	public void SetLinkid(Int32 v) {
        m_Linkid = v;
    }

	public void SetWarehousetype(Int32 v) {
        m_Warehousetype = v;
    }

	public void SetQuality(Int32 v) {
        m_Quality = v;
    }

	public void SetIcon(string v) {
        m_Icon = v;
    }

	public void SetTag(string v) {
        m_Tag = v;
    }

	public void SetPile(Int32 v) {
        m_Pile = v;
    }

	public void SetUsetype(Int32 v) {
        m_Usetype = v;
    }

	public void SetBundleuse(Int32 v) {
        m_Bundleuse = v;
    }

	public void SetSellvalue(string v) {
        if(v.Length != 0) {
           	m_Sellvalue = new List<Int32>();
           	string [] strs = v.Split(';');
           	for(int i =0;i < strs.Length; i++) {
               	string val = strs[i];
               	m_Sellvalue.Add(Convert.ToInt32(val));
           	}
        }
    }

	public void SetConvertvalue(string v) {
        if(v.Length != 0) {
           	m_Convertvalue = new List<Int32>();
           	string [] strs = v.Split(';');
           	for(int i =0;i < strs.Length; i++) {
               	string val = strs[i];
               	m_Convertvalue.Add(Convert.ToInt32(val));
           	}
        }
    }

	public void SetCoefficient(double v) {
        m_Coefficient = v;
    }

	public void SetTimelimit(double v) {
        m_Timelimit = v;
    }

	public void SetUsetimeslimit(Int32 v) {
        m_Usetimeslimit = v;
    }

	public void SetLevellimit(Int32 v) {
        m_Levellimit = v;
    }

}

public class ItemCfgLoader : Singleton<ItemCfgLoader> {
    public Dictionary<Int32, ItemCfg> m_cfgMap = new Dictionary<Int32, ItemCfg>();

    public ItemCfgLoader() {}
    ~ItemCfgLoader() {
        m_cfgMap.Clear();
    }

    public bool load(string path) {
        m_cfgMap.Clear();
        TextAsset binAsset = Resources.Load (path, typeof(TextAsset)) as TextAsset;         
        if(binAsset == null) {
            Debug.LogError("load path fail,file not exist, path: "+path);
            return false;
        }
        string [] lineArray = binAsset.text.Split ("\r"[0]);  
        for(int i =0;i < lineArray.Length; i++)  
        {  
            if(i < 3) {
                continue;
            }
            string [] strs = lineArray[i].Split (',');  
            if(strs.Length != 18) {
                Debug.LogError("line data invalid, path:"+path+",line:"+i);
                return false;
            }
            ItemCfg poCfg = new ItemCfg();
            Int32 index = Convert.ToInt32(strs[0]);

			poCfg.SetId(Convert.ToInt32(strs[0]));
			poCfg.SetName((strs[1]));
			poCfg.SetNote((strs[2]));
			poCfg.SetType(Convert.ToInt32(strs[3]));
			poCfg.SetLinkid(Convert.ToInt32(strs[4]));
			poCfg.SetWarehousetype(Convert.ToInt32(strs[5]));
			poCfg.SetQuality(Convert.ToInt32(strs[6]));
			poCfg.SetIcon((strs[7]));
			poCfg.SetTag((strs[8]));
			poCfg.SetPile(Convert.ToInt32(strs[9]));
			poCfg.SetUsetype(Convert.ToInt32(strs[10]));
			poCfg.SetBundleuse(Convert.ToInt32(strs[11]));
			poCfg.SetSellvalue(strs[12]);
			poCfg.SetConvertvalue(strs[13]);
			poCfg.SetCoefficient(Convert.ToDouble(strs[14]));
			poCfg.SetTimelimit(Convert.ToDouble(strs[15]));
			poCfg.SetUsetimeslimit(Convert.ToInt32(strs[16]));
			poCfg.SetLevellimit(Convert.ToInt32(strs[17]));

            if(m_cfgMap.ContainsKey(index)) {
                Debug.LogError("index duplicate!index:"+ index + ",path:"+path);
                return false;
            }
            m_cfgMap.Add(index, poCfg);
        }  

        return true;
    }

    public ItemCfg GetCfg(Int32 id) {
        if(m_cfgMap.ContainsKey(id)) {
            return m_cfgMap[id];
        }
        else {
            return null;
        }
    }
}


class ConfigMgr : Singleton<ConfigMgr> {
    public bool load(string path) {
         if (path.Length == 0) {
             return false;
         }

		if (!ItemCfgLoader.Instance.load(path + "Item")) {
		        Debug.LogError("load csv file: Item failed");
		        return false;
		}
        Debug.Log("load config finish");
        return true;
    }
}

