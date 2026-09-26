using Vintagestory.API.Common;
using Vintagestory.API.Server;
using Vintagestory.API.Datastructures;

namespace TheHeartlessWest;

public class THWWorldgen : ModSystem
{

        
        private ICoreServerAPI serverApi;
       

        public override void StartServerSide(ICoreServerAPI api)
        {
                serverApi = api;
                
                 

                api.Event.MapRegionGeneration(OnMapRegionGeneration, "standard");
                
                

        }

        private void OnMapRegionGeneration(IMapRegion mapRegion, int regionX, int regionZ, ITreeAttribute chunkGenParams)
        {

                int regionSize = serverApi.WorldManager.RegionSize;

                int mapSizeX = serverApi.WorldManager.MapSizeX;

                int regionStartX = regionX * regionSize;

                int regionCenterX = regionStartX + regionSize / 2;

                float westFactor = WestFactorCalculator.CalculateWestFactor(regionCenterX, mapSizeX);

                serverApi.Logger.Notification(westFactor.ToString("F6") + " west factor for region at X: " + regionCenterX);
                }
            



}