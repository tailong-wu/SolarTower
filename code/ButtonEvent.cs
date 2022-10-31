using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

using System.IO;
using System.Text;

public class ButtonEvent : MonoBehaviour
{
    public GameObject prefabTower;
    public GameObject prefabMirror;
    public void onClick(int para)
    {
        OpenFileName openFileName = new OpenFileName();
        openFileName.structSize = Marshal.SizeOf(openFileName);
        openFileName.filter = "txt文件(*.txt)\0*.txt";
        openFileName.file = new string(new char[256]);
        openFileName.maxFile = openFileName.file.Length;
        openFileName.fileTitle = new string(new char[64]);
        openFileName.maxFileTitle = openFileName.fileTitle.Length;
        openFileName.initialDir = Application.streamingAssetsPath.Replace('/', '\\');//默认路径
        openFileName.title = "窗口标题";
        openFileName.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000008;

        if (LocalDialog.GetSaveFileName(openFileName))
        {
            Debug.Log(openFileName.file);
            Debug.Log(openFileName.fileTitle);
        }
        loadTextAndCreate(openFileName.file);
    }


    void createMirror(Vector3 locate)
    {
        Instantiate(prefabMirror,locate,Quaternion.identity );
    }

    void createTower(Vector3 locate,float height)
    {
        Instantiate(prefabTower, locate, Quaternion.identity);
    }

    void loadTextAndCreate(string file_path)
    {
        StreamReader sr = new StreamReader(file_path, Encoding.Default);
        string line;
        string[] lineList;
        while ((line = sr.ReadLine()) != null)
        {
            lineList = line.Split(" ");
            createMirror(new Vector3(float.Parse(lineList[0]), 5.0f, float.Parse(lineList[2])));
        }
    }



    
}
