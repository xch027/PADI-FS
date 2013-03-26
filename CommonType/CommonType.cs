using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace CommonType
{
    public class ClientToMS : MarshalByRefObject
    {
        public string OpenMetadataFile(string fileName)
        {
            //READ FILE
            string filePath = @"D:\PADI-FS\M1\" + fileName;
            FileInfo file = new FileInfo(filePath);
            if (!file.Exists)
            {
                return "sorry, the file does not exist!";
            }
            StreamReader objReader = new StreamReader(filePath);
                            
            string sLine = "";
            string result = "";
            ArrayList LineList = new ArrayList();
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null && !sLine.Equals(""))
                    LineList.Add(sLine);
            }
            objReader.Close();

            //PRINT FILE
            //Console.WriteLine("The file content is:");
            foreach (var item in LineList)
            {
                result += item.ToString();
            }
            return result;
        }
        public void CloseMetadataFile()
        {
            //to-do
        }
        public void CreateMetadataFile(string fileName, int NoOfDS, int RQ, int WQ)
        {
            //CREATE FILE
            string filePath = @"D:\PADI-FS\M1\"+fileName;
            //file content: FileName|No.DS|RQ|WQ|PairList
            string fileContent = fileName+"|"+NoOfDS.ToString()+"|"+RQ.ToString()+"|"+WQ.ToString()+"|";
            fileContent += "D1:D2:D3:D4";
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(fileContent);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        public void deleteMetadataFile(string fileName)
        {
            //delete File
            string filePath = @"D:\PADI-FS\M1\" + fileName;
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                file.Delete(); //删除单个文件
            }
        }        
    }
    public class ClientToDS : MarshalByRefObject
    {
        public void printOnServer(string m)
        {
            Console.WriteLine(m);
        }
        //以下write可以用int型函数来返回成功（1）或失败（0）
        public string writeFile(string fileName,string fileContent) 
        {
            //WRITE FILE
            FileStream fs = new FileStream(@"D:\PADI-FS\D1\"+fileName, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(fileContent);
            sw.Flush();
            sw.Close();
            fs.Close();
            return "ACK...Writing file successfully!!!";
        }
        public string readFile(string fileName,string SEMANTIC)
        {
            //READ FILE
            StreamReader objReader = new StreamReader(@"D:\PADI-FS\D1\"+fileName);
            string sLine = "";
            string result = "";
            ArrayList LineList = new ArrayList();
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null && !sLine.Equals(""))
                    LineList.Add(sLine);
            }
            objReader.Close();

            //PRINT FILE
            //Console.WriteLine("The file content is:");
            foreach (var item in LineList)
            {
                result = result + item.ToString() + "\r\n";
            }
            return result;
        }
    }
}
