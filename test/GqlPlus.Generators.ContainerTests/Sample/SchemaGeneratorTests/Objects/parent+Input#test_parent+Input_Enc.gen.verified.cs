//HintName: test_parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Input;

public class testPrntInp
  : testRefPrntInp
  , ItestPrntInp
{
  public ItestPrntInpObject? As_PrntInp { get; set; }
}

public class testPrntInpObject
  : testRefPrntInpObject
  , ItestPrntInpObject
{

  public testPrntInpObject
    ( decimal parent
    ) : base(parent)
  {
  }
}

public class testRefPrntInp
  : GqlpEncoderBase
  , ItestRefPrntInp
{
  public string? AsString { get; set; }
  public ItestRefPrntInpObject? As_RefPrntInp { get; set; }
}

public class testRefPrntInpObject
  : GqlpEncoderBase
  , ItestRefPrntInpObject
{
  public decimal Parent { get; set; }

  public testRefPrntInpObject
    ( decimal parent
    )
  {
    Parent = parent;
  }
}
