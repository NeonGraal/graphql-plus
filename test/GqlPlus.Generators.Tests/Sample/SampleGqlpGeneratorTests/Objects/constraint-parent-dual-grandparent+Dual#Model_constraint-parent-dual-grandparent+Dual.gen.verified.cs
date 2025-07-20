//HintName: Model_constraint-parent-dual-grandparent+Dual.gen.cs
// Generated from constraint-parent-dual-grandparent+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_constraint_parent_dual_grandparent_Dual;

public interface ICnstPrntDualGrndDual
  : IRefCnstPrntDualGrndDual
{
}
public class DualCnstPrntDualGrndDual
  : DualRefCnstPrntDualGrndDual
  , ICnstPrntDualGrndDual
{
}

public interface IRefCnstPrntDualGrndDual<Tref>
  : Iref
{
}
public class DualRefCnstPrntDualGrndDual<Tref>
  : Dualref
  , IRefCnstPrntDualGrndDual<Tref>
{
}

public interface IGrndCnstPrntDualGrndDual
{
  String AsString { get; }
}
public class DualGrndCnstPrntDualGrndDual
  : IGrndCnstPrntDualGrndDual
{
  public String AsString { get; set; }
}

public interface IPrntCnstPrntDualGrndDual
  : IGrndCnstPrntDualGrndDual
{
}
public class DualPrntCnstPrntDualGrndDual
  : DualGrndCnstPrntDualGrndDual
  , IPrntCnstPrntDualGrndDual
{
}

public interface IAltCnstPrntDualGrndDual
  : IPrntCnstPrntDualGrndDual
{
  Number alt { get; }
}
public class DualAltCnstPrntDualGrndDual
  : DualPrntCnstPrntDualGrndDual
  , IAltCnstPrntDualGrndDual
{
  public Number alt { get; set; }
}
