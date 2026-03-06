//HintName: test_parent-dual+Input_Model.gen.cs
// Generated from {CurrentDirectory}parent-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Input;

public class testPrntDualInp
  : testRefPrntDualInp
  , ItestPrntDualInp
{
  public ItestPrntDualInpObject? As_PrntDualInp { get; set; }
}

public class testPrntDualInpObject
  : testRefPrntDualInpObject
  , ItestPrntDualInpObject
{

  public testPrntDualInpObject
    ( decimal parent
    ) : base(parent)
  {
  }
}

public class testRefPrntDualInp
  : GqlpModelImplementationBase
  , ItestRefPrntDualInp
{
  public string? AsString { get; set; }
  public ItestRefPrntDualInpObject? As_RefPrntDualInp { get; set; }
}

public class testRefPrntDualInpObject
  : GqlpModelImplementationBase
  , ItestRefPrntDualInpObject
{
  public decimal Parent { get; set; }

  public testRefPrntDualInpObject
    ( decimal parent
    )
  {
    Parent = parent;
  }
}
