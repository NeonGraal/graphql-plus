//HintName: Gqlp_generic-parent-dual+Dual_Intf.gen.cs
// Generated from generic-parent-dual+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_dual_Dual;

public interface IGnrcPrntDualDual
  : IRefGnrcPrntDualDual
{
}

public interface IRefGnrcPrntDualDual<Tref>
{
  Tref Asref { get; }
}

public interface IAltGnrcPrntDualDual
{
  Number alt { get; }
  String AsString { get; }
}
