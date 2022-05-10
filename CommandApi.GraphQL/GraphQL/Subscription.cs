using CommandApi.GraphQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommandApi.GraphQL
{
  public class Subscription
  {
    [Subscribe]
    [Topic]
    public Platform OnPlatformAdded([EventMessage] Platform platform)
    {
      return platform;
    }
  }
}