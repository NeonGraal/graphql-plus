//HintName: test_parent+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
    ( decimal parent
    ) : base(parent)
  {
  }
}

public class testRefPrntDual
  : GqlpModelImplementationBase
  , ItestRefPrntDual
{
  public string? AsString { get; set; }
  public ItestRefPrntDualObject? As_RefPrntDual { get; set; }
}

public class testRefPrntDualObject
  : GqlpModelImplementationBase
  , ItestRefPrntDualObject
{
  public decimal Parent { get; set; }

  public testRefPrntDualObject
    ( decimal parent
    )
  {
    Parent = parent;
  }
}
