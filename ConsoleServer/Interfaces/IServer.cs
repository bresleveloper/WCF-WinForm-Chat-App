﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    [ServiceContract(CallbackContract = typeof(IClient))]
    public interface IServer
    {
        [OperationContract(IsOneWay = true)]
        void Register(string clientName);

        [OperationContract(IsOneWay = true)]
        void AksClientsList();

        [OperationContract(IsOneWay = true)]
        void ClientSay(string msg, ChatUser clientFrom, ChatUser clientTo);

        [OperationContract(IsOneWay = true)]
        void AksUsersChatHistory(ChatUser a, ChatUser b);

        [OperationContract(IsOneWay = true)]
        void Broadcast(string msg);

    }
}
