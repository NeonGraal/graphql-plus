//HintName: test_parent-dual+Output_Impl.gen.cs
// Generated from {CurrentDirectory}parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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

  public testPrntDualOutpObject(decimal parent)
    : base(parent)
  {
  }
}

public class testRefPrntDualOutp
  : GqlpModelImplementationBase
  , ItestRefPrntDualOutp
{
  public string? AsString { get; set; }
  public ItestRefPrntDualOutpObject? As_RefPrntDualOutp { get; set; }
}

public class testRefPrntDualOutpObject
  : GqlpModelImplementationBase
  , ItestRefPrntDualOutpObject
{
  public decimal Parent { get; set; }

  public testRefPrntDualOutpObject(decimal parent)
  {
    Parent = parent;
  }
}
