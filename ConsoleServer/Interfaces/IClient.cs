﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IClient
    {
        [OperationContract(IsOneWay = true)]
        void PrintBroadcastMessage(string msg);

        [OperationContract(IsOneWay = true)]
        void RecieveFromClient(string msg, string clientName);

        [OperationContract(IsOneWay = true)]
        void RecieveClientsList(ChatUser[] clientList);

    }
}
