namespace GqlPlus.Building;

public class EnumValueBuilder
  : ErrorBuilder
{
  private readonly string _enumType;
  private readonly string _enumLabel;

  public EnumValueBuilder(string enumType, string enumLabel)
  {
    Add<IGqlpEnumValue>();

    _enumType = enumType;
    _enumLabel = enumLabel;
  }

  internal static void SetEnumValue(IGqlpEnumValue enumValue, string enumType, string enumLabel)
  {
    enumValue.EnumType.Returns(enumType);
    enumValue.EnumLabel.Returns(enumLabel);
    enumValue.EnumValue.Returns(enumType + "." + enumLabel);
  }

  protected new T Build<T>()
    where T : class, IGqlpEnumValue
  {
    T result = base.Build<T>();
    SetEnumValue(result, _enumType, _enumLabel);
    return result;
  }

  public IGqlpEnumValue AsEnumValue
    => Build<IGqlpEnumValue>();
}
