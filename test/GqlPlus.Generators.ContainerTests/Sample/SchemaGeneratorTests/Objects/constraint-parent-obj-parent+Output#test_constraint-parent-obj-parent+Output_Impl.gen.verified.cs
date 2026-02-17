//HintName: test_constraint-parent-obj-parent+Output_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Output;

public class testCnstPrntObjPrntOutp
  : testRefCnstPrntObjPrntOutp<ItestAltCnstPrntObjPrntOutp>
  , ItestCnstPrntObjPrntOutp
{
}

public class testRefCnstPrntObjPrntOutp<TRef>
  : ItestRefCnstPrntObjPrntOutp<TRef>
{
}

public class testPrntCnstPrntObjPrntOutp
  : ItestPrntCnstPrntObjPrntOutp
{
}

public class testAltCnstPrntObjPrntOutp
  : testPrntCnstPrntObjPrntOutp
  , ItestAltCnstPrntObjPrntOutp
{
  public decimal Alt { get; set; }
}
