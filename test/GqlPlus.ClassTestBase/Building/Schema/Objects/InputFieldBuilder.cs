using GqlPlus.Abstractions.Schema;
using NSubstitute.Core;

namespace GqlPlus.Building.Schema.Objects;

public class InputFieldBuilder
  : ObjFieldBuilder
  , IInputTypeBuilder
{
  private IGqlpConstant? _defaultValue;

  public InputFieldBuilder(string name, string type)
    : base(name, type)
    => Add<IGqlpInputField>();

  protected new T Build<T>()
    where T : class, IGqlpInputField
  {
    T result = base.Build<T>();

    result.DefaultValue.Returns(_defaultValue);

    return result;
  }

  public IGqlpInputField AsInputField
    => Build<IGqlpInputField>();

  public void SetDefaultValue(IGqlpConstant? defaultValue)
    => _defaultValue = defaultValue;
}
