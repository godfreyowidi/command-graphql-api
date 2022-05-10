using System.Linq;
using CommandApi.GraphQL.Data;
using CommandApi.GraphQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommandApi.GraphQL.Platforms
{
  public class PlatformType : ObjectType<Platform>
  {
    protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
    {
      descriptor.Description("Represents any service that has a command line interface.");

      descriptor
          .Field(p => p.LicenceKey).Ignore();

      descriptor
          .Field(p => p.Commands)
          .ResolveWith<Resolvers>(p => p.GetCommands(default, default!))
          .UseDbContext<AppDbContext>()
          .Description("The list of available commands for this platform.");
    }

    private class Resolvers
    {
      public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDbContext context)
      {
        return context.Commands.Where(p => p.PlatformId == platform.Id);
      }
    }
  }
}