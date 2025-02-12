using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    private UdpSender udpSender;

    void Start()
    {
        udpSender = new UdpSender("127.0.0.1", 12345);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("¡El cubo ha colisionado con " + other.gameObject.name + "!");
        
        udpSender.SendNumber(1.0f);
    }

    void OnApplicationQuit()
    {
        udpSender.Close();
    }
}
