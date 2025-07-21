//HintName: Gqlp_generic-parent-param-parent+Dual_Intf.gen.cs
// Generated from generic-parent-param-parent+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_param_parent_Dual;

public interface IGnrcPrntParamPrntDual
  : IRefGnrcPrntParamPrntDual
{
}

public interface IRefGnrcPrntParamPrntDual<Tref>
  : Iref
{
}

public interface IAltGnrcPrntParamPrntDual
{
  Number alt { get; }
  String AsString { get; }
}
