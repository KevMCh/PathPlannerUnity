using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;

public class UdpSender : MonoBehaviour
{
    public string host = "127.0.0.1";
    public int port = 12345;

    private UdpClient udpClient;

    void Start()
    {
        udpClient = new UdpClient();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float randomNumber = 1;
            SendNumber(randomNumber);
        }
    }

    public void SendNumber(float number)
    {
        try
        {
            byte[] data = FloatToByteArray(number);
            udpClient.Send(data, data.Length, host, port);
            Debug.Log($"Number sent: {number}");
        }
        catch (Exception e)
        {
            Debug.LogError($"Error sending: {e.Message}");
        }
    }

    byte[] FloatToByteArray(float value)
    {
        byte[] bytes = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }
        return bytes;
    }

    void OnApplicationQuit()
    {
        udpClient.Close();
    }
}