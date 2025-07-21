//HintName: Gqlp_generic-parent-param+Dual_Intf.gen.cs
// Generated from generic-parent-param+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_param_Dual;

public interface IGnrcPrntParamDual
  : IRefGnrcPrntParamDual
{
}

public interface IRefGnrcPrntParamDual<Tref>
{
  Tref Asref { get; }
}

public interface IAltGnrcPrntParamDual
{
  Number alt { get; }
  String AsString { get; }
}
