//HintName: test_parent-dual+Output_Model.gen.cs
// Generated from {CurrentDirectory}parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Output;

public class testPrntDualOutp
  : testRefPrntDualOutp
  , ItestPrntDualOutp
{
  public ItestPrntDualOutpObject? As_PrntDualOutp { get; set; }
}

public class testPrntDualOutpObject
  : testRefPrntDualOutpObject
  , ItestPrntDualOutpObject
{

  public testPrntDualOutpObject
    ( decimal pparent
    ) : base(pparent)
  {
  }
}

public class testRefPrntDualOutp
  : GqlpModelBase
  , ItestRefPrntDualOutp
{
  public string? AsString { get; set; }
  public ItestRefPrntDualOutpObject? As_RefPrntDualOutp { get; set; }
}

public class testRefPrntDualOutpObject
  : GqlpModelBase
  , ItestRefPrntDualOutpObject
{
  public decimal Parent { get; set; }

  public testRefPrntDualOutpObject
    ( decimal pparent
    )
  {
    Parent = pparent;
  }
}
