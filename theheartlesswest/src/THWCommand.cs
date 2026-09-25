using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;


namespace TheHeartlessWest;

public class THWCommand : ModSystem
{
    
    
public override void StartServerSide(ICoreServerAPI api)

        
    {
        int worldSizeX = api.WorldManager.MapSizeX;

            

          base.StartServerSide(api);
            api.ChatCommands.Create("thwclimate")
            .WithDescription("tells you your west factor")
            .RequiresPrivilege(Privilege.chat)
            .RequiresPlayer()
            .HandleWith((args) =>
             {
                var playerPosX = args.Caller.Entity.Pos.AsBlockPos.X;
                var calculateWestFactor = WestFactorCalculator.CalculateWestFactor(playerPosX, worldSizeX);
                 return TextCommandResult.Success("your west factor is " + calculateWestFactor.ToString("F3"));
             });

             

    }

    


}

