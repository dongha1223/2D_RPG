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
        talkData.Add(1000, new string[] { "뭘 쳐다보니?:1", "저리꺼지렴!:3" });
        talkData.Add(2000, new string[] { "골드메탈은 신이야!:2" });
        talkData.Add(4000, new string[] { "골드메탈이 직접만든 나무상자이다." });
        talkData.Add(5000, new string[] { "방금 버린 책상이다." });

        talkData.Add(10 + 1000, new string[] { "뭐야?:0", "나한테 한눈에 반했다고?:1", "....으 더러워:3" });
        talkData.Add(11 + 2000, new string[] { "골드메탈의 유니티 강의:1", "정말 좋아요:2", "골드메탈의 동전을 찾아줘!:3" });

        talkData.Add(20 + 3000, new string[] { "근처에서 동전을 찾았다."});

        talkData.Add(21 + 2000, new string[] { "고마워!:2", "보상으로 선물을 줄게!:2"});
        talkData.Add(30 + 1000, new string[] { "넌 절대 여기서 못나가:0","우리를 봐...:0"});

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
