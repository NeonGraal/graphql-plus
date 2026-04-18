//HintName: test_constraint-alt-dual+Input_Model.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Input;

public class testCnstAltDualInp
  : GqlpModelBase
  , ItestCnstAltDualInp
{
  public ItestRefCnstAltDualInp<ItestAltCnstAltDualInp>? AsRefCnstAltDualInp { get; set; }
  public ItestCnstAltDualInpObject? As_CnstAltDualInp { get; set; }
}

public class testCnstAltDualInpObject
  : GqlpModelBase
  , ItestCnstAltDualInpObject
{

  public testCnstAltDualInpObject
    ()
  {
  }
}

public class testRefCnstAltDualInp<TRef>
  : GqlpModelBase
  , ItestRefCnstAltDualInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefCnstAltDualInpObject<TRef>? As_RefCnstAltDualInp { get; set; }
}

public class testRefCnstAltDualInpObject<TRef>
  : GqlpModelBase
  , ItestRefCnstAltDualInpObject<TRef>
{

  public testRefCnstAltDualInpObject
    ()
  {
  }
}

public class testPrntCnstAltDualInp
  : GqlpModelBase
  , ItestPrntCnstAltDualInp
{
  public string? AsString { get; set; }
  public ItestPrntCnstAltDualInpObject? As_PrntCnstAltDualInp { get; set; }
}

public class testPrntCnstAltDualInpObject
  : GqlpModelBase
  , ItestPrntCnstAltDualInpObject
{

  public testPrntCnstAltDualInpObject
    ()
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

  public testAltCnstAltDualInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
