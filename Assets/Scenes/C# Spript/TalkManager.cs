using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> npcImageData;

    public Sprite[] npcImageArr;
    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        npcImageData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�� �Ĵٺ���?:1", "����������!:3" });
        talkData.Add(2000, new string[] { "����Ż�� ���̾�!:2" });
        talkData.Add(4000, new string[] { "����Ż�� �������� ���������̴�." });
        talkData.Add(5000, new string[] { "��� ���� å���̴�." });

        talkData.Add(10 + 1000, new string[] { "����?:0", "������ �Ѵ��� ���ߴٰ�?:1", "....�� ������:3" });
        talkData.Add(11 + 2000, new string[] { "����Ż�� ����Ƽ ����:1", "���� ���ƿ�:2", "����Ż�� ������ ã����!:3" });

        talkData.Add(20 + 3000, new string[] { "��ó���� ������ ã�Ҵ�."});

        talkData.Add(21 + 2000, new string[] { "����!:2", "�������� ������ �ٰ�!:2"});
        talkData.Add(30 + 1000, new string[] { "�� ���� ���⼭ ������:0","�츮�� ��...:0"});

        npcImageData.Add(1000 + 0, npcImageArr[0]);
        npcImageData.Add(1000 + 1, npcImageArr[1]);
        npcImageData.Add(1000 + 2, npcImageArr[2]);
        npcImageData.Add(1000 + 3, npcImageArr[3]);
        npcImageData.Add(2000 + 0, npcImageArr[4]);
        npcImageData.Add(2000 + 1, npcImageArr[5]);
        npcImageData.Add(2000 + 2, npcImageArr[6]);
        npcImageData.Add(2000 + 3, npcImageArr[7]);

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                return GetTalk(id - id % 10, talkIndex);
            }
        }

        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
    public Sprite GetNpcImage(int id, int npcImageIndex)
    {
        return npcImageData[id + npcImageIndex];
    }

}
