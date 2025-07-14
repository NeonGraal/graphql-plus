using GqlPlus.Abstractions.Schema;

namespace GqlPlus;

public static class SchemaBuilderHelpers
{
  public static T Aliased<T>(this IMockBuilder builder, string name, string[] aliases, string description = "")
    where T : class, IGqlpAliased
  {
    T result = builder.Named<T>(name, description);
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

  public static IGqlpInputParam InputParam(this IMockBuilder builder, string type, string description = "", bool isTypeParam = false)
  {
    IGqlpInputBase typeBase = builder.Named<IGqlpInputBase>(type, description);
    typeBase.IsTypeParam.Returns(isTypeParam);
    IGqlpInputParam input = builder.Descr<IGqlpInputParam>(description);
    input.Type.Returns(typeBase);
    return input;
  }

  public static T Named<T>(this IMockBuilder builder, string name)
    where T : class, IGqlpNamed
  {
    T result = builder.Error<T>();
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

  public static T[] NamedArray<T>(this IMockBuilder builder, params string[] names)
    where T : class, IGqlpNamed
    => builder.ArrayOf((b, i) => b.Named<T>(i), names);

  public static IGqlpTypeParam TypeParam(this IMockBuilder builder, string paramName, string constraint)
  {
    IGqlpTypeParam typeParam = builder.Named<IGqlpTypeParam>(paramName);
    typeParam.Constraint.Returns(constraint);
    return typeParam;
  }
}
