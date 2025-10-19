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

  protected new T Build<T>()
    where T : class, IGqlpEnumValue
  {
    T result = base.Build<T>();
    result.EnumType.Returns(_enumType);
    result.EnumLabel.Returns(_enumLabel);
    result.EnumValue.Returns(_enumType + "." + _enumLabel);
    return result;
  }

  public IGqlpEnumValue AsEnumValue
    => Build<IGqlpEnumValue>();
}
