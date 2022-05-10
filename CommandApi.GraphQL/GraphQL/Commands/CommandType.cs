using System.Linq;
using CommandApi.GraphQL.Data;
using CommandApi.GraphQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommandApi.GraphQL.Commands
{
  public class CommandType : ObjectType<Command>
  {
    protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
    {
      descriptor.Description("Represents a command that can be executed on a platform.");

      descriptor
          .Field(c => c.Platform)
          .ResolveWith<Resolvers>(c => c.GetPlatform(default, default!))
          .UseDbContext<AppDbContext>()
          .Description("The platform that this command can be applied on.");
    }

    private class Resolvers
    {
      public Platform GetPlatform(Command command, [ScopedService] AppDbContext context)
      {
        return context.Platforms.First(p => p.Id == command.PlatformId);
      }
    }
  }
}