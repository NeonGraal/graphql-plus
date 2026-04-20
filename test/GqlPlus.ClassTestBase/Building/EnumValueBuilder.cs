using GqlPlus.Ast;

namespace GqlPlus.Building;

public class EnumValueBuilder
  : ErrorBuilder
{
  private readonly string _enumType;
  private readonly string _enumLabel;

  public EnumValueBuilder(string enumType, string enumLabel)
  {
    Add<IAstEnumValue>();

    _enumType = enumType;
    _enumLabel = enumLabel;
  }

  internal static void SetEnumValue(IAstEnumValue enumValue, string enumType, string enumLabel)
  {
    enumValue.EnumType.Returns(enumType);
    enumValue.EnumLabel.Returns(enumLabel);
    enumValue.EnumValue.Returns(enumType + "." + enumLabel);
  }

  protected new T Build<T>()
    where T : class, IAstEnumValue
  {
    T result = base.Build<T>();
    SetEnumValue(result, _enumType, _enumLabel);
    return result;
  }

  public IAstEnumValue AsEnumValue
    => Build<IAstEnumValue>();
}
