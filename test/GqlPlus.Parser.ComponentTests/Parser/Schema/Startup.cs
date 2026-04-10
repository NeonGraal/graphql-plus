using GqlPlus.Abstractions.Schema;
using GqlPlus.Parser.Schema.Globals;
using GqlPlus.Parser.Schema.Objects;
using GqlPlus.Parser.Schema.Simple;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parser.Schema;

public static class Startup
{
  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddTransient<IBaseAliasedChecks<string, IAstSchemaCategory>, ParseCategoryChecks>()

      .AddTransient<IBaseAliasedChecks<string, IAstSchemaDirective>, ParseDirectiveChecks>()
      .AddOneChecks<IAstSchemaSetting>()
      .AddTransient<IBaseAliasedChecks<string, IAstSchemaOption>, ParseOptionChecks>()

      .AddTransient<IBaseDomainChecks<string, IAstDomain<IAstDomainTrueFalse>>, ParseDomainBooleanChecks>()
      .AddTransient<IBaseDomainChecks<DomainEnumInput, IAstDomain<IAstDomainLabel>>, ParseDomainEnumChecks>()
      .AddTransient<IBaseDomainChecks<string, IAstDomain<IAstDomainRange>>, ParseDomainNumberChecks>()
      .AddTransient<IBaseDomainChecks<DomainStringInput, IAstDomain<IAstDomainRegex>>, ParseDomainStringChecks>()

      .AddTransient<IBaseAliasedChecks<string, IAstEnumLabel>, ParseEnumLabelChecks>()
      .AddTransient<IBaseSimpleChecks<EnumInput, IAstEnum>, ParseEnumChecks>()
      .AddTransient<IBaseNamedChecks<string, IAstUnionMember>, ParseUnionMemberChecks>()
      .AddTransient<IBaseSimpleChecks<UnionInput, IAstUnion>, ParseUnionChecks>()

      .AddTransient<IParseTypeArgChecks, ParseTypeArgChecks>()
      .AddTransient<IParseObjBaseChecks, ParseObjBaseChecks>()

      .AddTransient<ICheckObjectField<IGqlpDualField>, ParseDualFieldChecks>()
      .AddTransient<ICheckObject<IGqlpDualField>, ParseDualChecks>()

      .AddTransient<ICheckObjectField<IGqlpInputField>, ParseInputFieldChecks>()
      .AddTransient<ICheckObject<IGqlpInputField>, ParseInputChecks>()

      .AddTransient<ICheckObjectField<IGqlpOutputField>, ParseOutputFieldChecks>()
      .AddTransient<ICheckObject<IGqlpOutputField>, ParseOutputChecks>()

      .AddComponentParsers();
}
