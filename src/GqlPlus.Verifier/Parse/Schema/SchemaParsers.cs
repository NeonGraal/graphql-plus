using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Parse.Schema;

public static class SchemaParsers
{
  public static IServiceCollection AddSchemaParsers(this IServiceCollection services)
    => services
      .AddSingleton<CategoryName>()
      .AddSingleton<IParser<NullAst>, ParseNull>()
      .AddSingleton<IParser<ParameterAst>, ParseParameter>()
      .AddSingleton<IParserArray<string>, ParseAliases>()
      .AddSingleton<TypeName>()
      // Category
      .AddSingleton<IParser<CategoryOption>, ParseCategoryOption>()
      .AddSingleton<IParser<CategoryOutput>, ParseCategoryDefinition>()
      .AddSingleton<IParser<CategoryAst>, ParseCategory>()
      // Directive
      .AddSingleton<DirectiveName>()
      .AddSingleton<IParser<DirectiveOption>, ParseDirectiveOption>()
      .AddSingleton<IParser<DirectiveLocation>, ParseDirectiveDefinition>()
      .AddSingleton<IParser<DirectiveAst>, ParseDirective>()
      // Enum
      .AddSingleton<IParser<EnumDefinition>, ParseEnumDefinition>()
      .AddSingleton<IParser<EnumLabelAst>, ParseEnumLabel>()
      .AddSingleton<IParser<EnumAst>, ParseEnum>()
      // Scalar
      .AddSingleton<IParser<ScalarDefinition>, ParseScalarDefinition>()
      .AddSingleton<IParser<ScalarRangeAst>, ParseScalarRange>()
      .AddSingleton<IParserArray<ScalarRangeAst>, ArrayParser<ScalarRangeAst>>()
      .AddSingleton<IParser<ScalarRegexAst>, ParseScalarRegex>()
      .AddSingleton<IParserArray<ScalarRegexAst>, ArrayParser<ScalarRegexAst>>()
      .AddSingleton<IParser<ScalarAst>, ParseScalar>()
      // Objects
      .AddSingleton<IParser<ObjectParameters>, ParseObjectParameters>()
      .AddObjectParser<ParseInput, ParseInputDefinition, InputAst, InputFieldAst, InputReferenceAst>()
      .AddObjectParser<ParseOutput, ParseOutputDefinition, OutputAst, OutputFieldAst, OutputReferenceAst>()
      // Schema
      .AddSingleton<IParser<SchemaAst>, ParseSchema>()
      ;

  public static IServiceCollection AddObjectParser<P, D, O, F, R>(this IServiceCollection services)
    where P : class, IObjectParser<O, F, R>
    where D : ParseObjectDefinition<F, R>
    where O : AstObject<F, R>
    where F : AstField<R>
    where R : AstReference<R>
    => services
      .AddSingleton<P>()
      .AddSingleton<IParser<O>>(x => x.GetRequiredService<P>())
      .AddFunc<IParser<F>>(x => x.GetRequiredService<P>().FieldIParser)
      .AddFunc<IParser<R>>(x => x.GetRequiredService<P>().ReferenceIParser)
      .AddSingleton<IParser<ObjectDefinition<F, R>>, D>()
      ;
}
