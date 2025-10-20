using GqlPlus.Abstractions.Schema;
using NSubstitute.Core;

namespace GqlPlus.Building.Schema.Objects;

public class ObjTypeBuilder
  : NamedBuilder
{
  internal bool _isTypeParam;

  public ObjTypeBuilder(string name)
    : base(name)
    => Add<IGqlpObjType>();

  protected new T Build<T>()
    where T : class, IGqlpObjType
  {
    T result = base.Build<T>();

    if (!_isTypeParam) {
      result.TypeName.Returns(_name);
      result.FullType.Returns(_name);
      return result;
    }

    result.IsTypeParam.Returns(true);
    result.TypeName.Returns("$" + _name);
    result.FullType.Returns("$" + _name);

    return result;
  }
}

public static class ObjTypeBuilderHelper
{
  public static T IsTypeParam<T>(this T builder, bool isTypeParam = true)
    where T : ObjTypeBuilder
    => builder.FluentAction(b => b._isTypeParam = isTypeParam);
}
