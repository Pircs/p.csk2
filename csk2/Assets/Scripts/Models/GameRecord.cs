using System;

namespace com.QH.QPGame.Services.Data
{

    [Serializable]
    public class GameRecordItem
	{
        public UInt64 dwEndTime; 				//��Ϸ����ʱ��
        public UInt32 dwGameKind;				//��Ϸ����
        public Int64 dwAmount;				//��Ӯ���
        public UInt32 dwAllCount; 			//�ܼ�¼
	}

    [Serializable]
    public class LogonRecordItem
	{
        public UInt64 dwTmlogonTime;			//��½ʱ��               
        public UInt32 dwLogonIP; 				//��½IP
	}
}

