using Vintagestory.API.Common;
using Vintagestory.API.Client;
using Vintagestory.API.Config;
using Vintagestory.API.Server;

namespace OutWest;

public class OutWestModSystem : ModSystem
{
      // Called on server and client
        public override void Start(ICoreAPI api)
        {
            Mod.Logger.Notification("Hello from outwest mod: " + Lang.Get("outwest:hello"));
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            float result = WestFactorCalculator.CalculateWestFactor(250, 1000);

            api.Logger.Notification("Out West test result: " + result);
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            Mod.Logger.Notification("Hello from outwest mod client side");
        }
}
