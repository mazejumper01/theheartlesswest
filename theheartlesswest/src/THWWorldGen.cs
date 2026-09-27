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


                // Climtate map stuff
                var climateMap = mapRegion.ClimateMap;

                
                
                if (climateMap == null)
                {
                     serverApi.Logger.Notification("Climate map is null");
                     return;
                      
                } 
                
    
                // Extract climate map information
                int climateInnerSize = climateMap.InnerSize;
                int climateMapSize = climateMap.Size;
                int climateMapTopLeftPadding = climateMap.TopLeftPadding;
                int climateMapBottomRightPadding = climateMap.BottomRightPadding;
                int climateMapDataLength = climateMap.Data.Length;
               

                int mismatchCount = 0;

                // Outer loop
                for (int climateX = 0; climateX < climateInnerSize; ++climateX) {  

                // Inner loop
                        for (int climateZ = 0; climateZ < climateInnerSize; climateZ++) 
                        {

                         int packedClimateValue = climateMap.GetUnpaddedInt(climateX, climateZ);


                        // Unpack climate value into temperature, rainfall, and low byte and repack it to verify correctness
                        int rawTemperature = (packedClimateValue >> 16) & 255;
                        int rawRainfall = (packedClimateValue >> 8) & 255; 
                        int lowByte = packedClimateValue & 255;
                        int repackedClimateValue = (rawTemperature << 16) | (rawRainfall << 8) | lowByte;
                        bool repackedValueMatchesOriginal = repackedClimateValue == packedClimateValue;

                        if (repackedValueMatchesOriginal == false )
                                {
                                     mismatchCount += 1;
                                }




                        }
                }
                
                

                // Log climate map information
                serverApi.Logger.Notification("Climate map is not null. InnerSize : " + climateInnerSize + ", Size: " + climateMapSize + ", TopLeftPadding: " + climateMapTopLeftPadding
                + ", BottomRightPadding: " + climateMapBottomRightPadding + ", Data Length: " + climateMapDataLength + ", the mismatch count is: " + mismatchCount);    
                

                serverApi.Logger.Notification(westFactor.ToString("F6") + " west factor for region at X: " + regionCenterX);
        }
            



}