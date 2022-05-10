using System.Linq;
using CommandApi.GraphQL.Data;
using CommandApi.GraphQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace CommandApi.GraphQL
{
  public class Query
  {
    [UseDbContext(typeof(AppDbContext))]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
    {
      return context.Platforms;
    }

    [UseDbContext(typeof(AppDbContext))]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Command> GetCommands([ScopedService] AppDbContext context)
    {
      return context.Commands;
    }
  }
}