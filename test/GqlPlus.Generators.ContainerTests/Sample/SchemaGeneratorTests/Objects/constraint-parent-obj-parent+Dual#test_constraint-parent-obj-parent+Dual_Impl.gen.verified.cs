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
}

public class testRefCnstPrntObjPrntDual<TRef>
  : ItestRefCnstPrntObjPrntDual<TRef>
{
}

public class testPrntCnstPrntObjPrntDual
  : ItestPrntCnstPrntObjPrntDual
{
}

public class testAltCnstPrntObjPrntDual
  : testPrntCnstPrntObjPrntDual
  , ItestAltCnstPrntObjPrntDual
{
  public decimal Alt { get; set; }
}
