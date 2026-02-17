//HintName: test_constraint-parent-dual-grandparent+Input_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Input;

public class testCnstPrntDualGrndInp
  : testRefCnstPrntDualGrndInp<ItestAltCnstPrntDualGrndInp>
  , ItestCnstPrntDualGrndInp
{
  public ItestCnstPrntDualGrndInpObject? As_CnstPrntDualGrndInp { get; set; }
}

public class testCnstPrntDualGrndInpObject
  : testRefCnstPrntDualGrndInpObject<ItestAltCnstPrntDualGrndInp>
  , ItestCnstPrntDualGrndInpObject
{

  public testCnstPrntDualGrndInpObject()
  {
  }
}

public class testRefCnstPrntDualGrndInp<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstPrntDualGrndInp<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefCnstPrntDualGrndInpObject<TRef>? As_RefCnstPrntDualGrndInp { get; set; }
}

public class testRefCnstPrntDualGrndInpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstPrntDualGrndInpObject<TRef>
{

  public testRefCnstPrntDualGrndInpObject()
  {
  }
}

public class testGrndCnstPrntDualGrndInp
  : GqlpModelImplementationBase
  , ItestGrndCnstPrntDualGrndInp
{
  public string? AsString { get; set; }
  public ItestGrndCnstPrntDualGrndInpObject? As_GrndCnstPrntDualGrndInp { get; set; }
}

public class testGrndCnstPrntDualGrndInpObject
  : GqlpModelImplementationBase
  , ItestGrndCnstPrntDualGrndInpObject
{

  public testGrndCnstPrntDualGrndInpObject()
  {
  }
}

public class testPrntCnstPrntDualGrndInp
  : testGrndCnstPrntDualGrndInp
  , ItestPrntCnstPrntDualGrndInp
{
  public ItestPrntCnstPrntDualGrndInpObject? As_PrntCnstPrntDualGrndInp { get; set; }
}

public class testPrntCnstPrntDualGrndInpObject
  : testGrndCnstPrntDualGrndInpObject
  , ItestPrntCnstPrntDualGrndInpObject
{

  public testPrntCnstPrntDualGrndInpObject()
  {
  }
}

public class testAltCnstPrntDualGrndInp
  : testPrntCnstPrntDualGrndInp
  , ItestAltCnstPrntDualGrndInp
{
  public ItestAltCnstPrntDualGrndInpObject? As_AltCnstPrntDualGrndInp { get; set; }
}

public class testAltCnstPrntDualGrndInpObject
  : testPrntCnstPrntDualGrndInpObject
  , ItestAltCnstPrntDualGrndInpObject
{
  public decimal Alt { get; set; }

  public testAltCnstPrntDualGrndInpObject(decimal alt)
  {
    Alt = alt;
  }
}
