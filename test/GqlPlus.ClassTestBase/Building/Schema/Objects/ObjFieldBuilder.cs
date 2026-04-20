using GqlPlus.Ast;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Building.Schema.Objects;

public class ObjFieldBuilder
  : AliasedBuilder
  , IObjTypeBuilder
  , IObjEnumBuilder
{
  private IAstModifier[] _modifiers = [];
  private IAstEnumValue? _enumValue;

  public ObjBaseBuilder BaseBuilder { get; }

  public ObjFieldBuilder(string name, string type)
    : base(name)
  {
    Add<IAstObjField>();
    Add<IAstObjFieldType>();
    Add<IAstModifiers>();
    Add<IAstObjEnum>();

    BaseBuilder = new ObjBaseBuilder(type);
  }

  protected new T Build<T>()
    where T : class, IAstObjField
  {
    T result = base.Build<T>();

    IAstObjBase type = BaseBuilder.AsObjBase;
    result.Type.Returns(type);
    string modifiedType = _modifiers.AsString().Prepend(type.FullType).Joined();
    result.ModifiedType.Returns(modifiedType);
    result.EnumValue.Returns(_enumValue);
    result.Modifiers.Returns(_modifiers);

    if (_enumValue is not null) {
      string typeName = _enumValue.EnumType;
      type.Name.Returns(typeName);
      type.FullType.Returns(typeName);
      result.EnumTypeName.Returns(typeName);
    }

    result.WhenForAnyArgs(a => a.SetEnumType("")).Do(this.MakeSetEnumValue(result, type));

    return result;
  }

  public void SetModifiers(IAstModifier[] modifiers)
    => _modifiers = modifiers;
  public void SetEnumValue(IAstEnumValue enumValue)
    => _enumValue = enumValue;

  public string Name => BaseBuilder._name;
}

public abstract class ObjFieldBuilder<T>
  : ObjFieldBuilder
  where T : class, IAstObjField
{
  protected ObjFieldBuilder(string name, string type)
    : base(name, type)
    => Add<T>();

  public abstract T AsObjField { get; }
}

public static class ObjFieldBuilderHelper
{
  public static T WithArg<T>(this T builder, string argType, Action<TypeArgBuilder>? config = null)
    where T : ObjFieldBuilder
    => builder.WithArgs(builder.TypeArg(argType).FluentAction(config).AsTypeArg);
  public static T WithArgs<T>(this T builder, params TypeArgBuilder[] args)
    where T : ObjFieldBuilder
    => builder.WithArgs([.. args.Select(a => a.AsTypeArg)]);
  public static T WithArgs<T>(this T builder, params IAstTypeArg[] args)
    where T : ObjFieldBuilder
    => builder.FluentAction(b => b.BaseBuilder._args = args);
  public static T IsTypeParam<T>(this T builder, bool isTypeParam = true)
    where T : ObjFieldBuilder
    => builder.FluentAction(b => b.BaseBuilder._isTypeParam = isTypeParam);
}
