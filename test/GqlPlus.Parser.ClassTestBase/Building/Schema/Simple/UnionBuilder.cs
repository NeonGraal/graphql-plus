using GqlPlus.Ast.Schema;

namespace GqlPlus.Building.Schema.Simple;

public class UnionBuilder
  : SimpleBuilder<IAstUnion>
{
  internal IAstUnionMember[] _members = [];

  public UnionBuilder(string name)
    : base(name)
  {
    Add<IAstUnion>();
    _typeKind = TypeKind.Union;
  }

  protected new T Build<T>()
    where T : class, IAstUnion
  {
    T result = base.Build<T>();
    result.Items.Returns(_members);
    return result;
  }

  public IAstUnion AsUnion
    => Build<IAstUnion>();

  public override IAstUnion AsSimple => AsUnion;
}

public static class UnionBuilderHelper
{
  public static T WithMembers<T>(this T builder, params IAstUnionMember[] members)
    where T : UnionBuilder
    => builder.FluentAction(b => b._members = members);
  public static T WithMembers<T>(this T builder, string[] members)
    where T : UnionBuilder
    => builder.WithMembers(members.AsArray(builder.Named<IAstUnionMember>));
}
