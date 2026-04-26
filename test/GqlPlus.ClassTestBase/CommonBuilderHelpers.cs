using GqlPlus.Building;
using GqlPlus.Token;

namespace GqlPlus;

public static class CommonBuilderHelpers
{
  public static T Of<T>(this IMockBuilder _)
    where T : class
    => Substitute.For<T>();
  public static T Of<T, T1>(this IMockBuilder _)
    where T : class
    where T1 : class
    => Substitute.For<T, T1>();
  public static T Of<T, T1, T2>(this IMockBuilder _)
    where T : class, T1
    where T1 : class, T2
    where T2 : class
    => Substitute.For<T, T1, T2>();

  public static TResult[] ArrayOf<TResult, TInput>(this IMockBuilder builder, Func<IMockBuilder, TInput, TResult> build, params TInput[] input)
    where TResult : class
    => [.. input.Select(i => build(builder, i))];

  public static T Error<T>(this IMockBuilder builder)
    where T : class, IAstError
  {
    T result = builder.Of<T>();
    result.MakeError("").ReturnsForAnyArgs(c => MakeMessages(c.ThrowIfNull().Arg<string>()));
    return result;
  }
  public static T Error<T, T1>(this IMockBuilder builder)
    where T : class, T1
    where T1 : class, IAstError
  {
    T result = builder.Of<T, T1>();
    result.MakeError("").ReturnsForAnyArgs(c => MakeMessages(c.ThrowIfNull().Arg<string>()));
    return result;
  }
  public static T Error<T, T1, T2>(this IMockBuilder builder)
    where T : class, T1
    where T1 : class, T2
    where T2 : class, IAstError
  {
    T result = builder.Of<T, T1, T2>();
    result.MakeError("").ReturnsForAnyArgs(c => MakeMessages(c.ThrowIfNull().Arg<string>()));
    return result;
  }

  public static IMessages MakeMessages(this string message)
    => new Messages { new TokenMessage(AstNulls.At, message) };

  public static FieldKeyBuilder FieldKey(this IMockBuilder _) => new();

  public static IAstFieldKey FieldKey(this IMockBuilder _, string text)
    => _.FieldKey().WithText(text).AsFieldKey;

  public static IAstFieldKey EnumFieldKey(this IMockBuilder _, string enumType, string enumLabel)
    => _.FieldKey().WithEnumValue(enumType, enumLabel).AsFieldKey;

  public static IAstEnumValue EnumValue(this IMockBuilder _, string enumType, string enumLabel)
    => new EnumValueBuilder(enumType, enumLabel).AsEnumValue;

  public static IAstFields<T> Fields<T>(this IMockBuilder _, string key, T value)
    => new FieldsBuilder<T>().WithField(key, value).AsFields;

  public static ConstantBuilder Constant(this IMockBuilder _) => new();

  public static IAstConstant Constant(this IMockBuilder _, string text)
    => _.Constant().WithText(text).AsConstant;

  public static IAstConstant Constant(this IMockBuilder _, IAstFieldKey value)
    => _.Constant().WithValue(value).AsConstant;

  public static IAstConstant Constant(this IMockBuilder _, string[] values)
    => _.Constant().WithValues(values).AsConstant;

  public static IAstConstant Constant(this IMockBuilder _, string key, IAstConstant value)
    => _.Constant().WithField(key, value).AsConstant;

  public static IAstModifier Modifier(this IMockBuilder _, ModifierKind kind, string key = "")
    => new ModifierBuilder(kind, key).AsModifier;
}
