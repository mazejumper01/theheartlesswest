using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;


namespace OutWest;

public class OutWestCommand : ModSystem
{
    
    
public override void StartServerSide(ICoreServerAPI api)

        
    {
        int worldSizeX = api.WorldManager.MapSizeX;

            

          base.StartServerSide(api);
            api.ChatCommands.Create("owc")
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

