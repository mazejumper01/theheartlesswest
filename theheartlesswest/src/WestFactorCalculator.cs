using Vintagestory.API.Common;


namespace TheHeartlessWest;

public class WestFactorCalculator : ModSystem

{
    
    public static float CalculateWestFactor(int x, int worldSizeX)
    {
       int worldCenterX = worldSizeX / 2;

       if (x < worldCenterX)
       {
        return (worldCenterX - x) / (float)worldCenterX;
       }else
         {
            
        return 0f;
         }

        
    }
    
    

}

