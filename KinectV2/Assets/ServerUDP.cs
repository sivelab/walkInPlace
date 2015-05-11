using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

using System.Threading;


public class ServerUDP : MonoBehaviour {
	
	Thread receiveThread;
	UdpClient client;
	public int port;
	IPEndPoint sender;
	// Use this for initialization
	void Start () {
		port = 9050;
		
		receiveThread = new Thread(new ThreadStart(ReceiveData));
		receiveThread.IsBackground = true;
		receiveThread.Start ();

		
   }	
	
	
	// Update is called once per frame
	void Update () {

		
		/*
      print("Message received from {0}:" + sender.ToString());
      print(Encoding.ASCII.GetString(data, 0, data.Length));

      string welcome = "Welcome to my test server";
      data = Encoding.ASCII.GetBytes(welcome);
      newsock.Send(data, data.Length, sender);

      while(true)
      {
         data = newsock.Receive(ref sender);
       
         Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));
         newsock.Send(data, data.Length, sender);
      }
      */
	}
	
	private void ReceiveData()
	{
	  guiText.text = "Connection Status \nWaiting...";
		client = new UdpClient(port);
		while (true)
		{
			try{
				IPEndPoint anyIP = new IPEndPoint (IPAddress.Any, 0);
      			byte[] data = new byte[1024];
				data = client.Receive(ref anyIP);
				string text = "";
				for (int i = 0; i < data.Length; i++)
				{
					text += data[i] + ":";
					if (i%4 == 0)
					{
						text += "\n";
					}
				}
				//string text = Encoding.UTF8.GetString(data);
				guiText.text = text;
			}
			catch(Exception e){
				guiText.text = e.ToString ();
			}
		}
	}
	
}
