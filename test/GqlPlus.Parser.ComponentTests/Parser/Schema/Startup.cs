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
      .AddTransient<IBaseAliasedChecks<string, IGqlpSchemaCategory>, ParseCategoryChecks>()

      .AddTransient<IBaseAliasedChecks<string, IGqlpSchemaDirective>, ParseDirectiveChecks>()
      .AddOneChecks<IGqlpSchemaSetting>()
      .AddTransient<IBaseAliasedChecks<string, IGqlpSchemaOption>, ParseOptionChecks>()
      .AddTransient<IBaseAliasedChecks<OperationInput, IGqlpSchemaOperation>, ParseOperationChecks>()

      .AddTransient<IBaseDomainChecks<string, IGqlpDomain<IGqlpDomainTrueFalse>>, ParseDomainBooleanChecks>()
      .AddTransient<IBaseDomainChecks<DomainEnumInput, IGqlpDomain<IGqlpDomainLabel>>, ParseDomainEnumChecks>()
      .AddTransient<IBaseDomainChecks<string, IGqlpDomain<IGqlpDomainRange>>, ParseDomainNumberChecks>()
      .AddTransient<IBaseDomainChecks<DomainStringInput, IGqlpDomain<IGqlpDomainRegex>>, ParseDomainStringChecks>()

      .AddTransient<IBaseAliasedChecks<string, IGqlpEnumLabel>, ParseEnumLabelChecks>()
      .AddTransient<IBaseSimpleChecks<EnumInput, IGqlpEnum>, ParseEnumChecks>()
      .AddTransient<IBaseNamedChecks<string, IGqlpUnionMember>, ParseUnionMemberChecks>()
      .AddTransient<IBaseSimpleChecks<UnionInput, IGqlpUnion>, ParseUnionChecks>()

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
