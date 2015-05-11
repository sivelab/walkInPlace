using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPSendPacket : MonoBehaviour {
	UdpClient udpClient;
	IPEndPoint remoteEndPointLeft;
	IPEndPoint remoteEndPointRight;
	public int port;
	public string IP;
	public string IPleft;
	public string IPright;
	public string[] firstbyte = new string[12];
	public string[] secondbyte = new string[12];	
	// Use this for initialization
	void Start () {
		IPleft = ReadShoeConfig.IPleftshoe;
		IPright = ReadShoeConfig.IPrightshoe;
		IP = "localhost";
		port = ReadShoeConfig.port;
		udpClient = new UdpClient();
		remoteEndPointLeft = new IPEndPoint(IPAddress.Parse(IPleft), port);
		remoteEndPointRight = new IPEndPoint(IPAddress.Parse(IPright), port);
		
	}
	
	// Update is called once per frame
	void Update () {
    try{
        // udpClient.Connect(IPleft, port);

         // Sends a message to the host to which you have connected.
			
		//Byte[] sendBytes = Encoding.ASCII.GetBytes("abcdef");

		//Byte[] sendBytes = Encoding.UTF8.GetBytes("Testing" );
			
			// sendbytes {}  , first byte is what type of data, bytes 2-3 first chamber, 4-5 second chamber
		//First Byte:
			// 1 = height
			// anything else = request for something
		
			Byte[] sendBytes = new Byte[25];
			sendBytes[0] = 1;
			for (int i = 0; i < 12; i++)
			{
				// 0     1    2     3    4      5
				//1-2   3-4  5-6   7-8  9-10   11-12  
				string twobytes = Convert.ToString(ReadShoeConfig.chambers[i],2).PadLeft(16,'0');
				firstbyte[i] = twobytes.Substring(0,8);
				secondbyte[i] = twobytes.Substring(8,8);
				sendBytes[(i*2)+1] = Convert.ToByte(firstbyte[i],2);
				sendBytes[(i*2)+2] = Convert.ToByte(secondbyte[i],2);
			}
			/*
			Byte[] sendBytes = new Byte[25];
			sendBytes[0] = 1;
			for (int i = 0; i < 25; i=i+2)
			{
				sendBytes[i+1] = Convert.ToByte(firstbyte[i]);
				sendBytes[i+2] = Convert.ToByte(secondbyte[i]);
			}
			*/
			//Byte[] sendBytes = {1,10,20,40,50,60,70,80,90,100,110,120,
			//	130,140,150,160,170,180,190,200,210,220,230,240,250};
			string rawdata = "";
			for (int i = 0; i <sendBytes.Length; i++)
			{
				rawdata+=  Convert.ToString ((sendBytes[i]),2).PadLeft(8,'0');
				if ((i+1)%5 == 0)
				{
					rawdata += "\n";
				}
			}
			string requestByte = Convert.ToString(sendBytes[0],2).PadLeft (8,'0');
			string myByteString = "";
			for (int i = 1; i < sendBytes.Length ; i = i + 2)
			{
				//1 3 5 7 9 11 13
				//1 2 3 4 5 6  7
				string chamberheight = Convert.ToString ((sendBytes[i]),2).PadLeft(8,'0') + Convert.ToString ((sendBytes[i+1]),2).PadLeft(8,'0');
			 	myByteString += "Chamber " + Convert.ToString (i/2+1).PadLeft(2,'0') +
			 		" : " + chamberheight + " | UInt16 Value : " + Convert.ToUInt16(chamberheight,2) +"\n"; 
	
			}
		//	Byte sendBytes = 24;

			
         udpClient.Send(sendBytes, sendBytes.Length,remoteEndPointLeft);
         udpClient.Send(sendBytes, sendBytes.Length,remoteEndPointRight);			
			guiText.text = "Sending Packets\n Sending!\nLeft Shoe IP=" + IPleft + "\nRight Shoe IP=" + IPright + "\nPort=" + port +
				"\nData :\nRequestTypeByte:" + 
				requestByte + "\n" + myByteString + "\nRawdata\n" + rawdata;
			/*
         // Blocks until a message returns on this socket from a remote host.
         Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint); 
         string returnData = Encoding.ASCII.GetString(receiveBytes);

         // Uses the IPEndPoint object to determine which of these two hosts responded.
         print("This is the message you received " +
    	                              returnData.ToString());
         print("This message was sent from " +
                                     RemoteIpEndPoint.Address.ToString() +
                                     " on their port number " +
                                     RemoteIpEndPoint.Port.ToString());

         // udpClient.Close();
        //  udpClientB.Close();
			 */
          }  
       catch (Exception e ) {
                  print(e.ToString());
        }
		
	}


}
