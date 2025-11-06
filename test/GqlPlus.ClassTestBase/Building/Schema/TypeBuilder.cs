using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema;

public class TypeBuilder
  : AliasedBuilder
{
  internal TypeKind _typeKind = TypeKind.Internal;

  public TypeBuilder(string name)
    : base(name)
    => Add<IGqlpType>();

  protected new T Build<T>()
    where T : class, IGqlpType
  {
    T result = base.Build<T>();
    result.Kind.Returns(_typeKind);
    return result;
  }
}

public static class TypeBuilderHelper
{
  public static T WithKind<T>(this T builder, TypeKind typeKind)
    where T : TypeBuilder
    => builder.FluentAction(b => b._typeKind = typeKind);
}
