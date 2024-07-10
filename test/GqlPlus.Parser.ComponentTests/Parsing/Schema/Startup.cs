using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing.Schema.Globals;
using GqlPlus.Parsing.Schema.Objects;
using GqlPlus.Parsing.Schema.Simple;

using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing.Schema;

public static class Startup
{
  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddSingleton<IBaseAliasedChecks<string, IGqlpSchemaCategory>, ParseCategoryChecks>()

      .AddSingleton<IBaseAliasedChecks<string, IGqlpSchemaDirective>, ParseDirectiveChecks>()
      .AddOneChecks<IGqlpSchemaSetting>()
      .AddSingleton<IBaseAliasedChecks<string, IGqlpSchemaOption>, ParseOptionChecks>()

      .AddSingleton<IBaseDomainChecks<string, IGqlpDomain<IGqlpDomainTrueFalse>>, ParseDomainBooleanChecks>()
      .AddSingleton<IBaseDomainChecks<DomainEnumInput, IGqlpDomain<IGqlpDomainMember>>, ParseDomainEnumChecks>()
      .AddSingleton<IBaseDomainChecks<string, IGqlpDomain<IGqlpDomainRange>>, ParseDomainNumberChecks>()
      .AddSingleton<IBaseDomainChecks<DomainStringInput, IGqlpDomain<IGqlpDomainRegex>>, ParseDomainStringChecks>()

      .AddSingleton<IBaseAliasedChecks<string, IGqlpEnumItem>, ParseEnumMemberChecks>()
      .AddSingleton<IBaseSimpleChecks<EnumInput, IGqlpEnum>, ParseEnumChecks>()
      .AddSingleton<IBaseNamedChecks<string, IGqlpUnionItem>, ParseUnionMemberChecks>()
      .AddSingleton<IBaseSimpleChecks<UnionInput, IGqlpUnion>, ParseUnionChecks>()

      .AddSingleton<ICheckObjectArgument<IGqlpDualArgument>, ParseDualArgumentChecks>()
      .AddSingleton<ICheckObjectBase<IGqlpDualBase>, ParseDualBaseChecks>()
      .AddSingleton<ICheckObjectField<IGqlpDualField>, ParseDualFieldChecks>()
      .AddSingleton<ICheckObject<IGqlpDualObject>, ParseDualChecks>()

      .AddSingleton<ICheckObjectArgument<IGqlpInputArgument>, ParseInputArgumentChecks>()
      .AddSingleton<ICheckObjectBase<IGqlpInputBase>, ParseInputBaseChecks>()
      .AddSingleton<ICheckObjectField<IGqlpInputField>, ParseInputFieldChecks>()
      .AddSingleton<ICheckObject<IGqlpInputObject>, ParseInputChecks>()

      .AddSingleton<ICheckObjectArgument<IGqlpOutputArgument>, ParseOutputArgumentChecks>()
      .AddSingleton<ICheckObjectBase<IGqlpOutputBase>, ParseOutputBaseChecks>()
      .AddSingleton<ICheckObjectField<IGqlpOutputField>, ParseOutputFieldChecks>()
      .AddSingleton<ICheckObject<IGqlpOutputObject>, ParseOutputChecks>()

      .AddComponentTest();
}
