using System;
using System.Collections.Generic;
using com.QH.QPGame.GameUtils;
using com.QH.QPGame.Services.Data;

namespace com.QH.QPGame.Lobby
{
    /// <summary>
    /// ����ģ�������
    /// 
    /// ֻ֧�����31��ģ������
    /// 0-8Ϊ����ģ��
    /// 8-16Ϊuiģ��
    /// 16-31Ϊ��Ϸģ��
    /// @Author: guofeng
    /// </summary>
    public class ModuleManager
    {
        private List<ModuleInfo> mModules;

        public ModuleManager()
        {
            mModules = new List<ModuleInfo>();
        }

        public void Clear()
        {
            mModules.Clear();
        }

        public void AnalyseByBin()
        {
            /*bool[] main = null;
            var strs = text.Split(',');
            for (uint i = 0; i < strs.Length; i++)
            {
                var str = strs[i];
                var dec = int.Parse(str);
                var bins = TextUtility.DecToBin(dec);

                if (i == 0)
                {
                    main = bins;
                    continue;
                }

                var index = i - 1;
                var moduleInfo = new ModuleInfo()
                {
                    ModuleID = index,
                    Enable = main.Length <= index ? false : main[index],
                    SubModuleInfo = bins
                };

                mModules.Add(index, moduleInfo);
            }*/
        }

        public bool ApplyDataFromStr(string text)
        {
            try
            {
				com.QH.QPGame.GameUtils.Logger.Sys.Log("ModuleInfo:" + text);
                mModules = LitJson.JsonMapper.ToObject<List<ModuleInfo>>(text);
                return true;
            }
            catch (Exception ex)
            {
				com.QH.QPGame.GameUtils.Logger.Sys.LogException(ex);
                return false;
            }
        }

        public bool IsModuleEnable(ModuleKind kind, int id)
        {
            var module = mModules.Find(info => info.ID == id && info.K == kind);
            return module == null ? false : module.S != 0;
        }

        public bool IsModuleExist(ModuleKind kind, int id)
        {
            var module = mModules.Find(info => info.ID == id && info.K == kind);
            return module != null;
        }

        public int GetModuleStatus(ModuleKind kind, int id, int sbID)
        {
            var module = mModules.Find(info => info.ID == id && info.K == kind);
            if (module == null) return -1;
            if (module.S == 0) return 0;
            return module.Sub.Length <= sbID ? 0 : module.Sub[sbID];
        }

        public ModuleInfo GetModuleInfo(int id, ModuleKind kind)
        {
            var module = mModules.Find(info => info.ID == id && info.K == kind);
            return module;
        }

        public List<ModuleInfo> GetModulesOfKind(ModuleKind kind)
        {
            var modules = mModules.FindAll(info => info.K == kind);
            return modules;
        }

    }
}

