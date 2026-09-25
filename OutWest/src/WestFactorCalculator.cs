using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;


namespace OutWest;

public class WestFactorCalculator
{
    public static float CalculateWestFactor(int x, int mapSizeX)
    {
       int worldCenterX = mapSizeX / 2;

       if (x < worldCenterX)
       {
        return (worldCenterX - x) / (float)worldCenterX;
       }else
         {
            
        return 0f;
         }

        
    }
    

}

