using GqlPlus.Abstractions.Schema;

using GqlPlus.Building;
using GqlPlus.Building.Schema;
using GqlPlus.Building.Schema.Objects;
using NSubstitute.Core;
namespace GqlPlus.Building.Schema;

public class InputParamBuilder
  : DescribedBuilder
  , IModifiersBuilder
  , IInputTypeBuilder
{
  private IGqlpModifier[] _modifiers = [];
  private IGqlpConstant? _defaultValue;

  public ObjBaseBuilder TypeBuilder { get; }

  public InputParamBuilder(string type)
    : base()
  {
    Add<IGqlpInputParam>();
    Add<IGqlpInputFieldType>();
    Add<IGqlpObjFieldType>();
    Add<IGqlpModifiers>();

    TypeBuilder = new ObjBaseBuilder(type);
  }

  protected new T Build<T>()
    where T : class, IGqlpInputParam
  {
    T result = base.Build<T>();

    IGqlpObjBase type = TypeBuilder.AsObjBase;
    result.Type.Returns(type);
    string modifiedType = _modifiers.AsString().Prepend(type.FullType).Joined();
    result.Modifiers.Returns(_modifiers);
    result.DefaultValue.Returns(_defaultValue);

    return result;
  }

  public IGqlpInputParam AsInputParam
    => Build<IGqlpInputParam>();

  public void SetModifiers(IEnumerable<IGqlpModifier> modifiers)
    => _modifiers = [.. modifiers];
  public void SetDefaultValue(IGqlpConstant? defaultValue)
    => _defaultValue = defaultValue;
}

public interface ITypeBuilder
  : IModifiersBuilder
{
  ObjBaseBuilder TypeBuilder { get; }
}

public static class TypeBuilderHelper
{
  public static T WithType<T>(this T builder, Action<ObjBaseBuilder> config)
    where T : ITypeBuilder
    => builder.FluentAction(b => config(b.TypeBuilder));
}

public interface IInputTypeBuilder
  : ITypeBuilder
{
  void SetDefaultValue(IGqlpConstant? defaultValue);
}


public static class InputTypeBuilderHelper
{
  public static T WithDefault<T>(this T builder, IGqlpConstant? defaultValue)
    where T : IInputTypeBuilder
    => builder.FluentAction(b => b.SetDefaultValue(defaultValue));
}
