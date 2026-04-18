//HintName: test_parent-dual+Input_Model.gen.cs
// Generated from {CurrentDirectory}parent-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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
  : GqlpModelBase
  , ItestRefPrntDualInp
{
  public string? AsString { get; set; }
  public ItestRefPrntDualInpObject? As_RefPrntDualInp { get; set; }
}

public class testRefPrntDualInpObject
  : GqlpModelBase
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
