//HintName: test_constraint-parent-dual-parent+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Dual;

public class testCnstPrntDualPrntDual
  : testRefCnstPrntDualPrntDual<ItestAltCnstPrntDualPrntDual>
  , ItestCnstPrntDualPrntDual
{
  public ItestCnstPrntDualPrntDualObject? As_CnstPrntDualPrntDual { get; set; }
}

public class testCnstPrntDualPrntDualObject
  : testRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual>
  , ItestCnstPrntDualPrntDualObject
{

  public testCnstPrntDualPrntDualObject()
  {
  }
}

public class testRefCnstPrntDualPrntDual<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstPrntDualPrntDual<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefCnstPrntDualPrntDualObject<TRef>? As_RefCnstPrntDualPrntDual { get; set; }
}

public class testRefCnstPrntDualPrntDualObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstPrntDualPrntDualObject<TRef>
{

  public testRefCnstPrntDualPrntDualObject()
  {
  }
}

public class testPrntCnstPrntDualPrntDual
  : GqlpModelImplementationBase
  , ItestPrntCnstPrntDualPrntDual
{
  public string? AsString { get; set; }
  public ItestPrntCnstPrntDualPrntDualObject? As_PrntCnstPrntDualPrntDual { get; set; }
}

public class testPrntCnstPrntDualPrntDualObject
  : GqlpModelImplementationBase
  , ItestPrntCnstPrntDualPrntDualObject
{

  public testPrntCnstPrntDualPrntDualObject()
  {
  }
}

public class testAltCnstPrntDualPrntDual
  : testPrntCnstPrntDualPrntDual
  , ItestAltCnstPrntDualPrntDual
{
  public ItestAltCnstPrntDualPrntDualObject? As_AltCnstPrntDualPrntDual { get; set; }
}

public class testAltCnstPrntDualPrntDualObject
  : testPrntCnstPrntDualPrntDualObject
  , ItestAltCnstPrntDualPrntDualObject
{
  public decimal Alt { get; set; }

  public testAltCnstPrntDualPrntDualObject(decimal alt)
  {
    Alt = alt;
  }
}
