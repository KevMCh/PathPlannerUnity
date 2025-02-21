using System;
using System.Net;
using System.Net.Sockets;

using UnityEngine;

public class UdpSender
{
    public string host = "127.0.0.1";
    public int port = 12350;

    private UdpClient udpClient;

    public UdpSender(string host, int port)
    {
        this.host = host;
        this.port = port;
        udpClient = new UdpClient();
    }

    public void SendNumber(float number)
    {
        try
        {
            byte[] data = FloatToByteArray(number);
            udpClient.Send(data, data.Length, host, port);
            Console.WriteLine($"Number sent: {number}");
            Debug.Log("Enviado");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error sending: {e.Message}");
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

    public void Close()
    {
        udpClient.Close();
    }
}
