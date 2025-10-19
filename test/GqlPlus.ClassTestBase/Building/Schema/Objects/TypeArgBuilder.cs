using GqlPlus.Abstractions.Schema;
using NSubstitute.Core;

namespace GqlPlus.Building.Schema.Objects;

public class TypeArgBuilder
  : NamedBuilder
{
  internal bool _isTypeParam;
  internal IGqlpEnumValue? _enumValue;

  public TypeArgBuilder(string name)
    : base(name)
    => Add<IGqlpTypeArg>();

  protected new T Build<T>()
    where T : class, IGqlpTypeArg
  {
    T result = base.Build<T>();
    result.EnumValue.Returns(_enumValue);
    if (_isTypeParam) {
      result.IsTypeParam.Returns(true);
      result.TypeName.Returns("$" + _name);
      result.FullType.Returns("$" + _name);
      return result;
    }

    result.TypeName.Returns(_name);
    result.EnumTypeName.Returns(_name);
    result.FullType.Returns(_name);
    result.WhenForAnyArgs(a => a.SetEnumType("")).Do(SetEnumType);

    return result;

    void SetEnumType(CallInfo c)
      => result.EnumTypeName.Returns(c.Arg<string>());
  }

  public IGqlpTypeArg AsTypeArg
    => Build<IGqlpTypeArg>();
}

public static class TypeArgBuilderHelper
{
  public static T IsTypeParam<T>(this T builder, bool isTypeParam = true)
    where T : TypeArgBuilder
    => builder.FluentAction(b => b._isTypeParam = isTypeParam);
  public static T WithEnumValue<T>(this T builder, IGqlpEnumValue enumValue)
    where T : TypeArgBuilder
    => builder.FluentAction(b => b._enumValue = enumValue);
  public static T WithEnumValue<T>(this T builder, string enumLabel)
    where T : TypeArgBuilder
    => builder.FluentAction(b => b._enumValue = builder.EnumValue(b._name, enumLabel));
}
