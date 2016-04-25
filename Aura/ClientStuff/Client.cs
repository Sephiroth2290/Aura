using System;
using Aura.Server;
using Aura.ClientStuff;
using Aura.MapRelated;
using Aura.ProcessRelated;
using Aura.Entity;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Windows.Controls;
using System.Windows;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels.Tcp;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Xml.Linq;
using System.Xml;

namespace Aura.ClientStuff
{
    public class Client
    {

        #region Variables

        public Location ServerLocation { get; set; }
        public Location ClientLocation { get; set; }

        public uint PlayerID { get; set; }
        public CharacterWindow Form { get; set; }

        #endregion



        #region ServerPacketHandler


        //private bool ServerPacketHandler(ref ServerPacket packet)
        //{
        //    Action method = null;
        //    if (packet == null)
        //        return false;
        //    switch ((ServerOpcode)packet.Opcode)
        //    {

        //        ///
        //        /// Redirect
        //        ///
        //        case ServerOpcode.Redirect:
        //            byte[] address = packet.Read(4);
        //            int port = (int)packet.ReadUInt16();
        //            byte num6 = packet.ReadByte();
        //            byte num7 = packet.ReadByte();
        //            byte[] buffer1 = packet.Read((int)packet.ReadByte());
        //            string str3 = packet.ReadString8();
        //            uint num9 = packet.ReadUInt32();
        //            Array.Reverse((Array)address);
        //            Program.Redirect = new IPEndPoint(new IPAddress(address), port);
        //            packet = new ServerPacket((byte)3);
        //            byte[] buffer2 = new byte[4]
        //            {
        //    (byte) 1,
        //    (byte) 0,
        //    (byte) 0,
        //    (byte) 127
        //            };
        //            packet.Write(buffer2);
        //            packet.WriteUInt16((ushort)2610);
        //            packet.WriteByte(num6);
        //            packet.WriteByte(num7);
        //            packet.WriteByte((byte)buffer1.Length);
        //            packet.Write(buffer1);
        //            packet.WriteString8(str3);
        //            packet.WriteUInt32(num9);
        //            break;

        //        ///
        //        /// Location
        //        ///

        //        case ServerOpcode.Location:
        //            this.ServerLocation.X = (int)packet.ReadUInt16();
        //            this.ServerLocation.Y = (int)packet.ReadUInt16();
        //            break;

        //        ///
        //        /// PlayerID
        //        /// 
        //        case ServerOpcode.PlayerID:
        //            //PlayerID = packet.ReadUInt32();
        //            //if (method == null)
        //            //{
        //            //    method = delegate
        //            //    {
        //            //        Form.Text = Name;
        //            //        Program.MainForm.clientTabs.TabPages.Add(Form);
        //            //    };
        //            //}
        //            //Program.MainForm.Invoke(method);
        //            //if (!Program.Alts.ContainsKey(Name.ToLower()))
        //            //{
        //            //    Program.Alts.Add(Name.ToLower(), this);
        //            //}
        //            //foreach (targetPlayer player in Program.Alts.Values.Where(client => client.targetplayer != null).SelectMany(client => client.targetplayer))
        //            //{
        //            //    player.updatePlayerTargets();
        //            //}
        //            //break;
        //    }
        //}


        #endregion
    }
}
