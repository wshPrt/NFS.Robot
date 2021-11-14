using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NFS.Commons.ScoketClient.TcpSocketClient;

namespace NFS.Commons.ScoketClient
{
   public class Data
    {
        public  void _tcp_Receipt(object sender, CmdDataPacket e)
        {
            TcpSocketClient socket = (TcpSocketClient)sender;
            var sb = new StringBuilder();
             Task.Run(() =>
            {
                for (int i = 0; i < e.Size; i++)
                {
                    if (i > 0)
                    {
                        sb.Append(" ");
                    }
                    sb.Append(e.Data[i].ToString("x"));
                    Console.WriteLine(sb.ToString());
                }
            });
      

            //  e.Data  55 aa 04 01            
           // var cmd = e.Data[3];
      
        }
    }
}
