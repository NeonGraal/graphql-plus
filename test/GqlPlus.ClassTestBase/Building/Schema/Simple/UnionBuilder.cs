using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Simple;

public class UnionBuilder
  : SimpleBuilder
{
  internal IGqlpUnionMember[] _members = [];

  public UnionBuilder(string name)
    : base(name)
  {
    Add<IGqlpUnion>();
    Add<IGqlpType>();
  }

  protected new T Build<T>()
    where T : class, IGqlpUnion
  {
    T result = base.Build<T>();
    result.Items.Returns(_members);
    return result;
  }

  public IGqlpUnion AsUnion
    => Build<IGqlpUnion>();
}

public static class UnionBuilderHelper
{
  public static T WithMembers<T>(this T builder, IEnumerable<IGqlpUnionMember> members)
    where T : UnionBuilder
    => builder.FluentAction(b => b._members = [.. members]);
  public static T WithMembers<T>(this T builder, IEnumerable<string> members)
    where T : UnionBuilder
    => builder.WithMembers(members.Select(builder.Named<IGqlpUnionMember>));
}
