//HintName: test_constraint-parent-obj-parent+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Dual;

public class testCnstPrntObjPrntDual
  : testRefCnstPrntObjPrntDual<ItestAltCnstPrntObjPrntDual>
  , ItestCnstPrntObjPrntDual
{
  public ItestCnstPrntObjPrntDualObject? As_CnstPrntObjPrntDual { get; set; }
}

public class testCnstPrntObjPrntDualObject
  : testRefCnstPrntObjPrntDualObject<ItestAltCnstPrntObjPrntDual>
  , ItestCnstPrntObjPrntDualObject
{

  public testCnstPrntObjPrntDualObject()
  {
  }
}

public class testRefCnstPrntObjPrntDual<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstPrntObjPrntDual<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefCnstPrntObjPrntDualObject<TRef>? As_RefCnstPrntObjPrntDual { get; set; }
}

public class testRefCnstPrntObjPrntDualObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstPrntObjPrntDualObject<TRef>
{

  public testRefCnstPrntObjPrntDualObject()
  {
  }
}

public class testPrntCnstPrntObjPrntDual
  : GqlpModelImplementationBase
  , ItestPrntCnstPrntObjPrntDual
{
  public string? AsString { get; set; }
  public ItestPrntCnstPrntObjPrntDualObject? As_PrntCnstPrntObjPrntDual { get; set; }
}

public class testPrntCnstPrntObjPrntDualObject
  : GqlpModelImplementationBase
  , ItestPrntCnstPrntObjPrntDualObject
{

  public testPrntCnstPrntObjPrntDualObject()
  {
  }
}

public class testAltCnstPrntObjPrntDual
  : testPrntCnstPrntObjPrntDual
  , ItestAltCnstPrntObjPrntDual
{
  public ItestAltCnstPrntObjPrntDualObject? As_AltCnstPrntObjPrntDual { get; set; }
}

public class testAltCnstPrntObjPrntDualObject
  : testPrntCnstPrntObjPrntDualObject
  , ItestAltCnstPrntObjPrntDualObject
{
  public decimal Alt { get; set; }

  public testAltCnstPrntObjPrntDualObject(decimal alt)
  {
    Alt = alt;
  }
}
