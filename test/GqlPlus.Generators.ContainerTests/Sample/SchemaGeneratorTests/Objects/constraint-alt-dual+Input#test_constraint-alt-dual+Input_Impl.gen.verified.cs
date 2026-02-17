//HintName: test_constraint-alt-dual+Input_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Input;

public class testCnstAltDualInp
  : GqlpModelImplementationBase
  , ItestCnstAltDualInp
{
  public ItestRefCnstAltDualInp<ItestAltCnstAltDualInp>? AsRefCnstAltDualInp { get; set; }
  public ItestCnstAltDualInpObject? As_CnstAltDualInp { get; set; }
}

public class testCnstAltDualInpObject
  : GqlpModelImplementationBase
  , ItestCnstAltDualInpObject
{

  public testCnstAltDualInpObject()
  {
  }
}

public class testRefCnstAltDualInp<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstAltDualInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltDualInpObject<TRef>? As_RefCnstAltDualInp { get; set; }
}

public class testRefCnstAltDualInpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstAltDualInpObject<TRef>
{

  public testRefCnstAltDualInpObject()
  {
  }
}

public class testPrntCnstAltDualInp
  : GqlpModelImplementationBase
  , ItestPrntCnstAltDualInp
{
  public string? AsString { get; set; }
  public ItestPrntCnstAltDualInpObject? As_PrntCnstAltDualInp { get; set; }
}

public class testPrntCnstAltDualInpObject
  : GqlpModelImplementationBase
  , ItestPrntCnstAltDualInpObject
{

  public testPrntCnstAltDualInpObject()
  {
  }
}

public class testAltCnstAltDualInp
  : testPrntCnstAltDualInp
  , ItestAltCnstAltDualInp
{
  public ItestAltCnstAltDualInpObject? As_AltCnstAltDualInp { get; set; }
}

public class testAltCnstAltDualInpObject
  : testPrntCnstAltDualInpObject
  , ItestAltCnstAltDualInpObject
{
  public decimal Alt { get; set; }

  public testAltCnstAltDualInpObject(decimal alt)
  {
    Alt = alt;
  }
}
