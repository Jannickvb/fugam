using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FugamUtil.Identifier
{
    [Serializable]
    public class FugamID
    {
        public int ClientID { get; }
        public int GameID { get; }

        public FugamID(int ClientId, int GameId)
        {
            ClientID = ClientId;
            GameID = GameId;
        }

        public override bool Equals(object obj)
        {
            if (obj is FugamID)
            {
                FugamID id = (FugamID) obj;
                return ClientID == id.ClientID;
            }
            return false;
        }

        public override string ToString()
        {
            return ClientID + "\n" + GameID;
        }
    }
}
