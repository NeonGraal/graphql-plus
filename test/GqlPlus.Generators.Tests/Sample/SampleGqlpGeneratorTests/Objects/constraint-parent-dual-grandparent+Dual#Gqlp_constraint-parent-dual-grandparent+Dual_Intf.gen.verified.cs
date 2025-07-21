//HintName: Gqlp_constraint-parent-dual-grandparent+Dual_Intf.gen.cs
// Generated from constraint-parent-dual-grandparent+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_dual_grandparent_Dual;

public interface ICnstPrntDualGrndDual
  : IRefCnstPrntDualGrndDual
{
}

public interface IRefCnstPrntDualGrndDual<Tref>
  : Iref
{
}

public interface IGrndCnstPrntDualGrndDual
{
  String AsString { get; }
}

public interface IPrntCnstPrntDualGrndDual
  : IGrndCnstPrntDualGrndDual
{
}

public interface IAltCnstPrntDualGrndDual
  : IPrntCnstPrntDualGrndDual
{
  Number alt { get; }
}
