using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;



namespace TheHeartlessWest;

public class WestFactorCalculator : ModSystem

{
    
    public static float CalculateWestFactor(int playerPosX, int worldSizeX)
    {
       int worldCenterX = worldSizeX / 2;

       if (playerPosX < worldCenterX)
       {
        return (worldCenterX - playerPosX) / (float)worldCenterX;
       }else
         {
            
        return 0f;
         }

        
    }
    
    

}

