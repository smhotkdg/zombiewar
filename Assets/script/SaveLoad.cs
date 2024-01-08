/*
 * 게임을 저장하고 로드합니다.
*/

using GooglePlayGames;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{    

    //게임 정보 저장하기
    public byte[] SaveGameInfo(DataInfo gi)
    {      
        byte[] temp = Serializer.ObjectToByteArraySerialize(gi);
        return temp;
    }

    //게임 정보 불러오기
    public DataInfo LoadGameInfo(byte[] bytes)
    {
        //GameObject.Find("GPGSManager").GetComponent<GPGSManager>().load
        return Serializer.Deserialize<DataInfo>(bytes);
    }

}
