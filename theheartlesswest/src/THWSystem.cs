using Vintagestory.API.Common;
using Vintagestory.API.Client;
using Vintagestory.API.Config;
using Vintagestory.API.Server;

namespace TheHeartlessWest;

public class THWSystem : ModSystem
{
      // Called on server and client
        public override void Start(ICoreAPI api)
        {
            Mod.Logger.Notification("Hello from The Heartless West mod: " + Lang.Get("The Heartless West:hello"));
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            float result = WestFactorCalculator.CalculateWestFactor(250, 1000);

            api.Logger.Notification("The Heartless West test result: " + result);

            
            
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            Mod.Logger.Notification("Hello from The Heartless West mod client side");
        }
}
