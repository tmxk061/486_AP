using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class NetworkSave : MonoBehaviour
{
    public static NetworkSave instance;

    public void Awake()
    {
        NetworkSave.instance = this;
    }
    


    public System.Net.Sockets.Socket socket1;

    string ipAdress = "192.168.0.32";
    int port = 9000;

    byte[] sendByte;
    private void Start()
    {
        //create socket
        socket1 = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //connect
        try
        {
            IPAddress ipAddr = IPAddress.Parse(ipAdress);
            IPEndPoint ipendPoint = new IPEndPoint(ipAddr, port);
            socket1.Connect(ipendPoint);

        }
        catch (SocketException se)
        {
            Debug.Log("Socket connect error ! : " + se.ToString());

            return;
        }
    }

    public void OnNetworkSave(string key, string name, string date)
    {

        List<List<int>> targetData = ES3.Load<List<List<int>>>(key);
        string NetworkSaveData = SeriallizeModulData(name, date, targetData);
        string packet = "Save!";
        string str = packet + NetworkSaveData;
        byte[] d = Encoding.Default.GetBytes(str);
        //socket.Send(d, l, 0);
        SendData(socket1, d);

        Debug.Log(str);
    }

    private string SeriallizeModulData(string name,string date, List<List<int>> realData)
    {
        string result = name + "#" + date + "#" + "@";

        for (int i = 0; i < realData.Count; i++)
        {
            for (int a = 0; a < realData[i].Count; a++)
            {
                result += realData[i][a];
                result += "$";
            }
            result += "@";
        }

        return result;
    }

    public void SendData(System.Net.Sockets.Socket sock, byte[] data)
    {
        try
        {
            int total = 0;
            int size = data.Length;
            int left_data = size;
            int send_data = 0;

            // 전송할 데이터의 크기 전달
            byte[] data_size = new byte[4];
            data_size = BitConverter.GetBytes(size);
            send_data = sock.Send(data_size);

            // 실제 데이터 전송
            while (total < size)
            {
                send_data = sock.Send(data, total, left_data, SocketFlags.None);
                total += send_data;
                left_data -= send_data;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void ReceiveData(System.Net.Sockets.Socket sock, ref byte[] data)
    {
        try
        {
            int total = 0;
            int size = 0;
            int left_data = 0;
            int recv_data = 0;

            // 수신할 데이터 크기 알아내기 
            byte[] data_size = new byte[4];
            recv_data = sock.Receive(data_size, 0, 4, SocketFlags.None);
            size = BitConverter.ToInt32(data_size, 0);
            left_data = size;

            data = new byte[size];

            // 실제 데이터 수신
            while (total < size)
            {
                recv_data = sock.Receive(data, total, left_data, 0);
                if (recv_data == 0) break;
                total += recv_data;
                left_data -= recv_data;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw ex;
        }
    }

}
