using Vintagestory.API.Common;
using Vintagestory.API.Client;
using Vintagestory.API.Config;
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

        public void OnMapRegionGeneration(IMapRegion mapRegion, int regionX, int regionZ, ITreeAttribute chunkGenParams)
        {

                int regionSize = serverApi.WorldManager.RegionSize;

                int regionStartX = regionX * regionSize;

                int regionCenterX = regionStartX + regionSize / 2;

            serverApi.Logger.Notification(regionX + " " + regionSize + " " + regionStartX + " " + regionCenterX);


                
                        
                }
            



}