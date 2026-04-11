using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Building.Schema;

public class InputParamBuilder
  : DescribedBuilder
  , IModifiersBuilder
  , IInputTypeBuilder
{
  private IAstModifier[] _modifiers = [];
  private IAstConstant? _defaultValue;

  public ObjBaseBuilder BaseBuilder { get; }

  public InputParamBuilder(string type)
    : base()
  {
    Add<IAstInputParam>();
    Add<IAstInputFieldType>();
    Add<IAstObjFieldType>();
    Add<IAstModifiers>();

    BaseBuilder = new ObjBaseBuilder(type);
  }

  protected new T Build<T>()
    where T : class, IAstInputParam
  {
    T result = base.Build<T>();

    IAstObjBase type = BaseBuilder.AsObjBase;
    result.Type.Returns(type);
    string modifiedType = _modifiers.AsString().Prepend(type.FullType).Joined();
    result.Modifiers.Returns(_modifiers);
    result.DefaultValue.Returns(_defaultValue);

    return result;
  }

  public IAstInputParam AsInputParam
    => Build<IAstInputParam>();

  public void SetModifiers(IAstModifier[] modifiers)
    => _modifiers = modifiers;
  public void SetDefaultValue(IAstConstant? defaultValue)
    => _defaultValue = defaultValue;
}

public interface IObjTypeBuilder
  : IModifiersBuilder
{
  ObjBaseBuilder BaseBuilder { get; }
}

public static class ObjTypeBuilderHelper
{
  public static T WithType<T>(this T builder, Action<ObjBaseBuilder> config)
    where T : IObjTypeBuilder
    => builder.FluentAction(b => config(b.BaseBuilder));
}

public interface IInputTypeBuilder
  : IObjTypeBuilder
{
  void SetDefaultValue(IAstConstant? defaultValue);
}

public static class InputTypeBuilderHelper
{
  public static T WithDefault<T>(this T builder, IAstConstant? defaultValue)
    where T : IInputTypeBuilder
    => builder.FluentAction(b => b.SetDefaultValue(defaultValue));
}
