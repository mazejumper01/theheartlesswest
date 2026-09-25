using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;


namespace OutWest;

public class OutWestCommand : ModSystem
{
    
    
public override void StartServerSide(ICoreServerAPI api)
    {
          base.StartServerSide(api);
            api.ChatCommands.Create("owc")
            .WithDescription("tells you your west factor")
            .RequiresPrivilege(Privilege.chat)
            .RequiresPlayer()
            .HandleWith((args) =>
             {
                
                 return TextCommandResult.Success("your west factor is");
             });
    }


}

