﻿namespace boombang_emulator.src.Handlers.FlowerPower
{
    internal class MenuHandler
    {
        public static void Invoke()
        {
            //HandlerController.SetHandler(128125, new ProcessHandler(GoToScenery));
        }
        //private static void GoToScenery(Client client, ClientMessage clientMessage)
        //{
        //    try
        //    {
        //        if (client.User == null)
        //        {
        //            throw new Exception("-");
        //        }

        //        int accessibilityTypeId = Convert.ToInt32(clientMessage.Parameters[0, 0]);
        //        int scenaryId = Convert.ToInt32(clientMessage.Parameters[1, 0]);
        //        switch (accessibilityTypeId)
        //        {
        //            case 1:
        //                PublicScenery publicScenery = PublicSceneryLoader.publicSceneries[scenaryId] ?? throw new Exception("-");
        //                if (
        //                    (client.User.Scenery != null && client.User.Scenery != publicScenery)
        //                    || client.User.Scenery == null
        //                    )
        //                {
        //                    client.User.SetScenery(publicScenery);
        //                    client.User.SetActualPositionInScenery(publicScenery);
        //                    publicScenery.AddClient(client);

        //                    LoadUserPacket.Invoke(client, publicScenery);
        //                    GoToSceneryPacket.Invoke(client, publicScenery);
        //                }
        //                break;
        //            case 2:
        //                break;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        client.Close();
        //    }
        //}
    }
}
