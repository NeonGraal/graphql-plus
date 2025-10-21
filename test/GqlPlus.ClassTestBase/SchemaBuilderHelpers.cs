using GqlPlus.Abstractions.Schema;
using GqlPlus.Building.Schema;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus;

public static class SchemaBuilderHelpers
{
  public static T Aliased<T>(this IMockBuilder _, string name, string[] aliases, string description = "")
    where T : class, IGqlpAliased
    => new AliasedBuilder<T>(name)
      .WithAliases(aliases)
      .WithDescr(description)
      .AsAliased;
  public static T Aliased<T, T1>(this IMockBuilder builder, string name, string[] aliases, string description = "")
    where T : class, T1
    where T1 : class, IGqlpAliased
  {
    T result = builder.Named<T, T1>(name, description);
    result.Aliases.Returns(aliases);
    return result;
  }
  public static T Aliased<T, T1, T2>(this IMockBuilder builder, string name, string[] aliases, string description = "")
    where T : class, T1
    where T1 : class, T2
    where T2 : class, IGqlpAliased
  {
    T result = builder.Named<T, T1, T2>(name, description);
    result.Aliases.Returns(aliases);
    return result;
  }

  public static T Descr<T>(this IMockBuilder builder, string description)
    where T : class, IGqlpDescribed
  {
    T result = builder.Error<T>();
    result.Description.Returns(description);
    return result;
  }
  public static T Descr<T, T1>(this IMockBuilder builder, string description)
    where T : class, T1
    where T1 : class, IGqlpDescribed
  {
    T result = builder.Error<T, T1>();
    result.Description.Returns(description);
    return result;
  }
  public static T Descr<T, T1, T2>(this IMockBuilder builder, string description)
    where T : class, T1
    where T1 : class, T2
    where T2 : class, IGqlpDescribed
  {
    T result = builder.Error<T, T1, T2>();
    result.Description.Returns(description);
    return result;
  }

  public static InputParamBuilder InputParam(this IMockBuilder _, string typeName)
    => new(typeName);

  public static T Named<T>(this IMockBuilder builder, string name)
    where T : class, IGqlpNamed
  {
    T result = builder.Error<T>();
    result.Name.Returns(name);
    return result;
  }
  public static T Named<T, T1>(this IMockBuilder builder, string name)
    where T : class, T1
    where T1 : class, IGqlpNamed
  {
    T result = builder.Error<T, T1>();
    result.Name.Returns(name);
    return result;
  }

  public static T Named<T>(this IMockBuilder builder, string name, string description)
    where T : class, IGqlpNamed
  {
    T result = builder.Descr<T>(description);
    result.Name.Returns(name);
    return result;
  }
  public static T Named<T, T1>(this IMockBuilder builder, string name, string description)
    where T : class, T1
    where T1 : class, IGqlpNamed
  {
    T result = builder.Descr<T, T1>(description);
    result.Name.Returns(name);
    return result;
  }
  public static T Named<T, T1, T2>(this IMockBuilder builder, string name, string description)
    where T : class, T1
    where T1 : class, T2
    where T2 : class, IGqlpNamed
  {
    T result = builder.Descr<T, T1, T2>(description);
    result.Name.Returns(name);
    return result;
  }

  public static T[] NamedArray<T>(this IMockBuilder builder, params string[] names)
    where T : class, IGqlpNamed
    => builder.ArrayOf((b, i) => b.Named<T>(i), names);

  public static IGqlpTypeParam TypeParam(this IMockBuilder _, string paramName, string constraint)
    => new TypeParamBuilder(paramName, constraint).AsTypeParam;
}
