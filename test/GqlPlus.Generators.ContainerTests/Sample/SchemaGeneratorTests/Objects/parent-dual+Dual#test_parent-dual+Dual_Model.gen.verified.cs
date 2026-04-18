//HintName: test_parent-dual+Dual_Model.gen.cs
// Generated from {CurrentDirectory}parent-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Dual;

public class testPrntDualDual
  : testRefPrntDualDual
  , ItestPrntDualDual
{
  public ItestPrntDualDualObject? As_PrntDualDual { get; set; }
}

public class testPrntDualDualObject
  : testRefPrntDualDualObject
  , ItestPrntDualDualObject
{

  public testPrntDualDualObject
    ( decimal parent
    ) : base(parent)
  {
  }
}

public class testRefPrntDualDual
  : GqlpModelBase
  , ItestRefPrntDualDual
{
  public string? AsString { get; set; }
  public ItestRefPrntDualDualObject? As_RefPrntDualDual { get; set; }
}

public class testRefPrntDualDualObject
  : GqlpModelBase
  , ItestRefPrntDualDualObject
{
  public decimal Parent { get; set; }

  public testRefPrntDualDualObject
    ( decimal parent
    )
  {
    Parent = parent;
  }
}
