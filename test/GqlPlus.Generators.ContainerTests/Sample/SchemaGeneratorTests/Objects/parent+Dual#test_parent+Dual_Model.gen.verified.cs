//HintName: test_parent+Dual_Model.gen.cs
// Generated from {CurrentDirectory}parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Dual;

public class testPrntDual
  : testRefPrntDual
  , ItestPrntDual
{
  public ItestPrntDualObject? As_PrntDual { get; set; }
}

public class testPrntDualObject
  : testRefPrntDualObject
  , ItestPrntDualObject
{

  public testPrntDualObject
    ( decimal pparent
    ) : base(pparent)
  {
  }
}

public class testRefPrntDual
  : GqlpModelBase
  , ItestRefPrntDual
{
  public string? AsString { get; set; }
  public ItestRefPrntDualObject? As_RefPrntDual { get; set; }
}

public class testRefPrntDualObject
  : GqlpModelBase
  , ItestRefPrntDualObject
{
  public decimal Parent { get; set; }

  public testRefPrntDualObject
    ( decimal pparent
    )
  {
    Parent = pparent;
  }
}
