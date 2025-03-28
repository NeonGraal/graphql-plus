using GqlPlus.Abstractions.Schema;
using GqlPlus.Schema.Globals;
using GqlPlus.Schema.Objects;
using GqlPlus.Schema.Simple;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Schema;

public static class Startup
{
  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddTransient<IBaseAliasedChecks<string, IGqlpSchemaCategory>, ParseCategoryChecks>()

      .AddTransient<IBaseAliasedChecks<string, IGqlpSchemaDirective>, ParseDirectiveChecks>()
      .AddOneChecks<IGqlpSchemaSetting>()
      .AddTransient<IBaseAliasedChecks<string, IGqlpSchemaOption>, ParseOptionChecks>()

      .AddTransient<IBaseDomainChecks<string, IGqlpDomain<IGqlpDomainTrueFalse>>, ParseDomainBooleanChecks>()
      .AddTransient<IBaseDomainChecks<DomainEnumInput, IGqlpDomain<IGqlpDomainLabel>>, ParseDomainEnumChecks>()
      .AddTransient<IBaseDomainChecks<string, IGqlpDomain<IGqlpDomainRange>>, ParseDomainNumberChecks>()
      .AddTransient<IBaseDomainChecks<DomainStringInput, IGqlpDomain<IGqlpDomainRegex>>, ParseDomainStringChecks>()

      .AddTransient<IBaseAliasedChecks<string, IGqlpEnumLabel>, ParseEnumLabelChecks>()
      .AddTransient<IBaseSimpleChecks<EnumInput, IGqlpEnum>, ParseEnumChecks>()
      .AddTransient<IBaseNamedChecks<string, IGqlpUnionMember>, ParseUnionMemberChecks>()
      .AddTransient<IBaseSimpleChecks<UnionInput, IGqlpUnion>, ParseUnionChecks>()

      .AddTransient<ICheckObjectArg<IGqlpDualArg>, ParseDualArgChecks>()
      .AddTransient<ICheckObjectBase<IGqlpDualBase>, ParseDualBaseChecks>()
      .AddTransient<ICheckObjectField<IGqlpDualField>, ParseDualFieldChecks>()
      .AddTransient<ICheckObject<IGqlpDualObject>, ParseDualChecks>()

      .AddTransient<ICheckObjectArg<IGqlpInputArg>, ParseInputArgChecks>()
      .AddTransient<ICheckObjectBase<IGqlpInputBase>, ParseInputBaseChecks>()
      .AddTransient<ICheckObjectField<IGqlpInputField>, ParseInputFieldChecks>()
      .AddTransient<ICheckObject<IGqlpInputObject>, ParseInputChecks>()

      .AddTransient<ICheckObjectArg<IGqlpOutputArg>, ParseOutputArgChecks>()
      .AddTransient<ICheckObjectBase<IGqlpOutputBase>, ParseOutputBaseChecks>()
      .AddTransient<ICheckObjectField<IGqlpOutputField>, ParseOutputFieldChecks>()
      .AddTransient<ICheckObject<IGqlpOutputObject>, ParseOutputChecks>()

      .AddComponentTest();
}
