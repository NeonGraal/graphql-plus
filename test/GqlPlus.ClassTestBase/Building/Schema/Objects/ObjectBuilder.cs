using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Objects;

public class ObjectBuilder
  : TypeBuilder
{
  internal IGqlpTypeParam[] _typeParams = [];
  internal IGqlpAlternate[] _alternates = [];

  public ObjBaseBuilder? BaseBuilder { get; internal set; }

  public ObjectBuilder(string name, TypeKind kind)
    : base(name)
  {
    Add<IGqlpObject>();
    _typeKind = kind;
  }

  protected new T Build<T>()
    where T : class, IGqlpObject
  {
    T result = base.Build<T>();

    IGqlpObjBase? parent = BaseBuilder?.AsObjBase;

    result.Label.Returns(_typeKind.ToString());
    result.Parent.Returns(parent);
    result.TypeParams.Returns(_typeParams);
    result.Alternates.Returns(_alternates);

    return result;
  }
}

public class ObjectBuilder<TField>
  : ObjectBuilder
  where TField : class, IGqlpObjField
{
  internal TField[] _fields = [];

  public ObjectBuilder(string name, TypeKind kind)
    : base(name, kind)
    => Add<IGqlpObject<TField>>();

  protected new T Build<T>()
    where T : class, IGqlpObject<TField>
  {
    T result = base.Build<T>();

    IGqlpObjBase? parent = BaseBuilder?.AsObjBase;

    result.Fields.Returns(_fields);
    result.ObjFields.Returns(_fields);

    return result;
  }

  public IGqlpObject<TField> AsObject
    => Build<IGqlpObject<TField>>();
}

public static class ObjectBuilderHelper
{
  public static T WithParent<T>(this T builder, string parent = "", Action<ObjBaseBuilder>? config = null)
    where T : ObjectBuilder
    => builder.FluentAction(b => b.BaseBuilder = SetParent(parent, config));

  private static ObjBaseBuilder? SetParent(string parent = "", Action<ObjBaseBuilder>? config = null)
    => string.IsNullOrWhiteSpace(parent) ? null
      : new ObjBaseBuilder(parent).FluentAction(config);

  public static T WithTypeParam<T>(this T builder, string paramName, string constraint)
    where T : ObjectBuilder
    => builder.WithTypeParams(builder.TypeParam(paramName, constraint));
  public static T WithTypeParams<T>(this T builder, params IGqlpTypeParam[] typeParams)
    where T : ObjectBuilder
    => builder.FluentAction(b => b._typeParams = typeParams);

  public static T WithObjFields<T, TField>(this T builder, params TField[] fields)
    where T : ObjectBuilder<TField>
    where TField : class, IGqlpObjField
    => builder.FluentAction(b => b._fields = fields);

  public static T WithAlternate<T>(this T builder, string typeName, Action<AlternateBuilder>? config = null)
    where T : ObjectBuilder
    => builder.WithAlternates(builder.Alternate(typeName).FluentAction(config));
  public static T WithAlternates<T>(this T builder, params AlternateBuilder[] alternates)
    where T : ObjectBuilder
    => builder.WithAlternates([.. alternates.Select(a => a.AsAlternate)]);
  public static T WithAlternates<T>(this T builder, params IGqlpAlternate[] alternates)
    where T : ObjectBuilder
    => builder.FluentAction(b => b._alternates = alternates);
}
