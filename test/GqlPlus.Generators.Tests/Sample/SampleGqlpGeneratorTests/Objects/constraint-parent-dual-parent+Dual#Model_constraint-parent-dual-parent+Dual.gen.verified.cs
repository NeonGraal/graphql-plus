//HintName: Model_constraint-parent-dual-parent+Dual.gen.cs
// Generated from constraint-parent-dual-parent+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_constraint_parent_dual_parent_Dual;

public interface ICnstPrntDualPrntDual
  : IRefCnstPrntDualPrntDual
{
}
public class DualCnstPrntDualPrntDual
  : DualRefCnstPrntDualPrntDual
  , ICnstPrntDualPrntDual
{
}

public interface IRefCnstPrntDualPrntDual<Tref>
  : Iref
{
}
public class DualRefCnstPrntDualPrntDual<Tref>
  : Dualref
  , IRefCnstPrntDualPrntDual<Tref>
{
}

public interface IPrntCnstPrntDualPrntDual
{
  String AsString { get; }
}
public class DualPrntCnstPrntDualPrntDual
  : IPrntCnstPrntDualPrntDual
{
  public String AsString { get; set; }
}

public interface IAltCnstPrntDualPrntDual
  : IPrntCnstPrntDualPrntDual
{
  Number alt { get; }
}
public class DualAltCnstPrntDualPrntDual
  : DualPrntCnstPrntDualPrntDual
  , IAltCnstPrntDualPrntDual
{
  public Number alt { get; set; }
}
