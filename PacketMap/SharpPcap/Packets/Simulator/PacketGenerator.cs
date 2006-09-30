// $Id: PacketGenerator.java,v 1.5 2001/06/27 02:17:33 pcharles Exp $

/// <summary>************************************************************************
/// Copyright (C) 2001, Patrick Charles and Jonas Lehmann                   *
/// Distributed under the Mozilla Public License                            *
/// http://www.mozilla.org/NPL/MPL-1.1.txt                                *
/// *************************************************************************
/// </summary>
namespace Tamir.IPLib.Packets.Simulator
{
	using System;
	using HexHelper = Tamir.IPLib.Packets.Util.HexHelper;
	using ArrayHelper = Tamir.IPLib.Packets.Util.ArrayHelper;
	using EthernetProtocols = Tamir.IPLib.Packets.EthernetProtocols;
	using EthernetFields = Tamir.IPLib.Packets.EthernetFields;
	using IPFields = Tamir.IPLib.Packets.IPFields;
	using IPProtocols = Tamir.IPLib.Packets.IPProtocols;
	/// <summary> This class produces data fabricated to look like it originated from a 
	/// network device.
	/// *
	/// </summary>
	/// <author>  Patrick Charles and Jonas Lehmann
	/// </author>
	/// <version>  $Revision: 1.5 $
	/// @lastModifiedBy $Author: pcharles $
	/// @lastModifiedAt $Date: 2001/06/27 02:17:33 $
	/// 
	/// </version>
	public class PacketGenerator : EthernetFields, IPFields
	{
		/// <summary> Generate a pseudo-random network packet.
		/// </summary>
		/// <returns> an array of bytes containing a randomly generated 
		/// ethernet network packet. Packet can encapsulate any known protocol.
		/// 
		/// </returns>
		public static byte[] generate()
		{
			// create ethernet header
			byte[] packet = HeaderGenerator.generateRandomEthernetHeader();
			int eProto = ArrayHelper.extractInteger(packet, Tamir.IPLib.Packets.EthernetFields.ETH_CODE_POS, Tamir.IPLib.Packets.EthernetFields.ETH_CODE_LEN);
			
			// figure out what type of packet should be encapsulated after the 
			// newly generated ethernet header.
			switch (eProto)
			{
				
				case Tamir.IPLib.Packets.EthernetProtocols_Fields.IP: 
					byte[] ipHeader = HeaderGenerator.generateRandomIPHeader();
					packet = ArrayHelper.join(packet, ipHeader);
					
					// figure out what type of protocol should be encapsulated after the 
					// newly generated IP header.
					int ipProto = ArrayHelper.extractInteger(ipHeader, Tamir.IPLib.Packets.IPFields_Fields.IP_CODE_POS, Tamir.IPLib.Packets.IPFields_Fields.IP_CODE_LEN);
					switch (ipProto)
					{
						
						case Tamir.IPLib.Packets.IPProtocols_Fields.UDP: 
							byte[] udpHeader = HeaderGenerator.generateRandomUDPHeader();
							packet = ArrayHelper.join(packet, udpHeader);
							break;
						
						case Tamir.IPLib.Packets.IPProtocols_Fields.ICMP: 
							byte[] icmpHeader = HeaderGenerator.generateRandomICMPHeader();
							packet = ArrayHelper.join(packet, icmpHeader);
							break;
						
						case Tamir.IPLib.Packets.IPProtocols_Fields.TCP: 
							byte[] tcpHeader = HeaderGenerator.generateRandomTCPHeader();
							packet = ArrayHelper.join(packet, tcpHeader);
							break;
						
						default: 
							break;
						
					}
					break;
				
				case Tamir.IPLib.Packets.EthernetProtocols_Fields.ARP: 
					byte[] arpHeader = HeaderGenerator.generateRandomARPHeader();
					packet = ArrayHelper.join(packet, arpHeader);
					break;
				
				default: 
					break;
				
			}
			
			return packet;
		}
		
		
		/// <summary> Unit test.
		/// </summary>
		[STAThread]
		public static void  Main1(System.String[] args)
		{
			byte[] bytes = HeaderGenerator.generateRandomEthernetHeader();
			System.Console.Error.WriteLine(HexHelper.toString(bytes));
			
			bytes = HeaderGenerator.generateRandomIPHeader();
			System.Console.Error.WriteLine(HexHelper.toString(bytes));
			
			bytes = HeaderGenerator.generateRandomARPHeader();
			System.Console.Error.WriteLine(HexHelper.toString(bytes));
		}
		
		
		private System.String _rcsid = "$Id: PacketGenerator.java,v 1.5 2001/06/27 02:17:33 pcharles Exp $";
	}
}