using GqlPlus.Abstractions.Schema;
using NSubstitute.Core;

namespace GqlPlus.Building.Schema;

public class AliasedBuilder
  : NamedBuilder
{
  internal string[] _aliases = [];

  public AliasedBuilder(string name)
    : base(name)
    => Add<IGqlpAliased>();

  protected new T Build<T>()
    where T : class, IGqlpAliased
  {
    T result = base.Build<T>();
    result.Aliases.Returns(_aliases);
    result.IsNameOrAlias(Arg.Any<string>()).Returns(ReturnThis(result));
    return result;

    Func<CallInfo, bool> ReturnThis(T aliased)
      => callInfo => {
        string id = callInfo.Arg<string>();
        return string.Equals(aliased.Name, id, StringComparison.Ordinal)
          || aliased.Aliases.Contains(id, StringComparer.Ordinal);
      };
  }
}

public class AliasedBuilder<T>
  : AliasedBuilder
    where T : class, IGqlpAliased
{
  public AliasedBuilder(string name)
    : base(name)
    => Add<T>();

  public T AsAliased
    => Build<T>();
}

public static class AliasedBuilderHelper
{
  public static T WithAliases<T>(this T builder, string[] aliases)
    where T : AliasedBuilder
    => builder.FluentAction(b => b._aliases = aliases);
}
