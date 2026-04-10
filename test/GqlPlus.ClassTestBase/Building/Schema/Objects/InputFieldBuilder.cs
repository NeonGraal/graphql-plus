using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Objects;

public class InputFieldBuilder
  : ObjFieldBuilder<IAstInputField>
  , IInputTypeBuilder
{
  private IAstConstant? _defaultValue;

  public InputFieldBuilder(string name, string type)
    : base(name, type)
    => Add<IAstInputField>();

  protected new T Build<T>()
    where T : class, IAstInputField
  {
    T result = base.Build<T>();

    result.DefaultValue.Returns(_defaultValue);

    return result;
  }

  public IAstInputField AsInputField
    => Build<IAstInputField>();

  public override IAstInputField AsObjField
    => AsInputField;

  public void SetDefaultValue(IAstConstant? defaultValue)
    => _defaultValue = defaultValue;
}
