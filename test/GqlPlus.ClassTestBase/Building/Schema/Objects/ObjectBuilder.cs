using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Objects;

public class ObjectBuilder
  : AliasedBuilder
{
  internal IGqlpTypeParam[] _typeParams = [];
  internal IGqlpObjField[] _fields = [];
  internal IGqlpAlternate[] _alternates = [];
  private readonly TypeKind _kind;

  public ObjBaseBuilder? BaseBuilder { get; internal set; }

  public ObjectBuilder(string name, TypeKind kind)
    : base(name)
  {
    Add<IGqlpObject>();
    Add<IGqlpType>();
    _kind = kind;
  }

  protected new T Build<T>()
    where T : class, IGqlpObject
  {
    T result = base.Build<T>();

    IGqlpObjBase? parent = BaseBuilder?.AsObjBase;

    result.Kind.Returns(_kind);
    result.Label.Returns(_kind.ToString());
    result.Parent.Returns(parent);
    result.TypeParams.Returns(_typeParams);
    result.Fields.Returns(_fields);
    result.Alternates.Returns(_alternates);

    return result;
  }
}

public class ObjectBuilder<T>
  : ObjectBuilder
  where T : class, IGqlpObject
{
  public ObjectBuilder(string name, TypeKind kind)
    : base(name, kind)
    => Add<T>();

  public T AsObject
    => Build<T>();
}

public static class ObjectBuilderHelper
{
  public static T WithParent<T>(this T builder, string parent = "", Action<ObjBaseBuilder>? config = null)
    where T : ObjectBuilder
    => builder.FluentAction(b => b.BaseBuilder = SetParent(parent, config));

  private static ObjBaseBuilder? SetParent(string parent = "", Action<ObjBaseBuilder>? config = null)
  {
    if (string.IsNullOrWhiteSpace(parent)) {
      return null;
    }

    ObjBaseBuilder objBaseBuilder = new(parent);
    config?.Invoke(objBaseBuilder);

    return objBaseBuilder;
  }

  public static T WithTypeParams<T>(this T builder, params IGqlpTypeParam[] typeParams)
    where T : ObjectBuilder
    => builder.FluentAction(b => b._typeParams = typeParams);
  public static T WithFields<T>(this T builder, params IGqlpObjField[] fields)
    where T : ObjectBuilder
    => builder.FluentAction(b => b._fields = fields);
  public static T WithAlternates<T>(this T builder, params IGqlpAlternate[] alternates)
    where T : ObjectBuilder
    => builder.FluentAction(b => b._alternates = alternates);
}
