﻿using GqlPlus.Verifier.Ast;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Parse.Common;

public static class CommonParsers
{
  public static IServiceCollection AddCommonParsers(this IServiceCollection services)
    => services
      .AddSingleton<IParser<FieldKeyAst>, ParseFieldKey>()
      .AddSingleton<IParserArray<ModifierAst>, ParseModifiers>()
      .AddSingleton<IParserDefault, ParseDefault>()
      .AddParserValue<ConstantAst, ParseConstant>();

  public static IServiceCollection AddParserValue<T, P>(this IServiceCollection services)
    where P : class, IParser<T>, IParserValue<T>, IParser<Field<T>>
    where T : AstValue<T>
    => services
      .AddSingleton<P>()
      .AddSingleton<IParser<T>>(x => x.GetRequiredService<P>())
      .AddSingleton<IParserValue<T>>(x => x.GetRequiredService<P>())
      .AddSingleton<IParser<Field<T>>>(x => x.GetRequiredService<P>());
}
