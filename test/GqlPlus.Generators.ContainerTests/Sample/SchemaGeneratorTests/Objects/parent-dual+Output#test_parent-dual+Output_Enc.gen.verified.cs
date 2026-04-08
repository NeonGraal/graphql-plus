//HintName: test_parent-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
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

  public testPrntDualOutpObject
    ( decimal parent
    ) : base(parent)
  {
  }
}

public class testRefPrntDualOutp
  : GqlpEncoderBase
  , ItestRefPrntDualOutp
{
  public string? AsString { get; set; }
  public ItestRefPrntDualOutpObject? As_RefPrntDualOutp { get; set; }
}

public class testRefPrntDualOutpObject
  : GqlpEncoderBase
  , ItestRefPrntDualOutpObject
{
  public decimal Parent { get; set; }

  public testRefPrntDualOutpObject
    ( decimal parent
    )
  {
    Parent = parent;
  }
}
