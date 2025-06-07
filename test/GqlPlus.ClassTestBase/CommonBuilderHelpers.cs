﻿using GqlPlus.Abstractions;
using GqlPlus.Ast;
using GqlPlus.Token;
using NSubstitute;

namespace GqlPlus;

public static class CommonBuilderHelpers
{
  public static T Of<T>(this IMockBuilder _)
    where T : class
    => Substitute.For<T>();

  public static T Of<T, T1>(this IMockBuilder _)
    where T : class where T1 : class
    => Substitute.For<T, T1>();

  public static TResult[] ArrayOf<TResult, TInput>(this IMockBuilder builder, Func<IMockBuilder, TInput, TResult> build, params TInput[] input)
    where TResult : class
    => [.. input.Select(i => build(builder, i))];

  public static T Error<T>(this IMockBuilder builder)
    where T : class, IGqlpError
  {
    T result = builder.Of<T>();
    result.MakeError("").ReturnsForAnyArgs(c => MakeMessages(c.ThrowIfNull().Arg<string>()));
    return result;
  }

  public static ITokenMessages MakeMessages(this string message)
    => new TokenMessages { new TokenMessage(AstNulls.At, message) };

  public static IGqlpFieldKey FieldKey(this IMockBuilder builder, string text)
  {
    IGqlpFieldKey fieldKey = builder.Of<IGqlpFieldKey>();
    fieldKey.Text.Returns(text);
    return fieldKey;
  }

  public static IGqlpFields<T> Fields<T>(this IMockBuilder builder, string key, T value)
  {
    IGqlpFieldKey fieldKey = builder.FieldKey(key);
    Dictionary<IGqlpFieldKey, T> dict = new() { [fieldKey] = value };
    IGqlpFields<T> fields = builder.Of<IGqlpFields<T>>();
    fields.Count.Returns(1);
    fields.GetEnumerator().Returns(dict.GetEnumerator());

    return fields;
  }

  public static IGqlpConstant Constant(this IMockBuilder builder, string text)
  {
    IGqlpFieldKey fieldKey = builder.FieldKey(text);
    IGqlpConstant constant = builder.Of<IGqlpConstant>();
    constant.Value.Returns(fieldKey);
    return constant;
  }

  public static IGqlpConstant Constant(this IMockBuilder builder, string[] values)
  {
    IGqlpConstant constant = builder.Of<IGqlpConstant>();
    IGqlpConstant[] constantValues = builder.ArrayOf((b, v) => b.Constant(v), values);
    constant.Values.Returns(constantValues);
    return constant;
  }

  public static IGqlpConstant Constant(this IMockBuilder builder, string key, IGqlpConstant value)
  {
    IGqlpConstant constant = builder.Of<IGqlpConstant>();
    IGqlpFields<IGqlpConstant> fields = builder.Fields(key, value);
    constant.Fields.Returns(fields);

    return constant;
  }

  public static IGqlpModifier Modifier(this IMockBuilder builder, ModifierKind kind, string key = "")
  {
    IGqlpModifier modifier = builder.Error<IGqlpModifier>();
    modifier.ModifierKind.Returns(kind);
    modifier.Key.Returns(key);
    return modifier;
  }
}
