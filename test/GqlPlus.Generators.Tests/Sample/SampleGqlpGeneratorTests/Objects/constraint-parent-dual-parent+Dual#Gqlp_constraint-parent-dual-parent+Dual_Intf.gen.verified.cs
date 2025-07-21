//HintName: Gqlp_constraint-parent-dual-parent+Dual_Intf.gen.cs
// Generated from constraint-parent-dual-parent+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_dual_parent_Dual;

public interface ICnstPrntDualPrntDual
  : IRefCnstPrntDualPrntDual
{
}

public interface IRefCnstPrntDualPrntDual<Tref>
  : Iref
{
}

public interface IPrntCnstPrntDualPrntDual
{
  String AsString { get; }
}

public interface IAltCnstPrntDualPrntDual
  : IPrntCnstPrntDualPrntDual
{
  Number alt { get; }
}
