//HintName: test_parent-alt+Input_Enc.gen.cs
// Generated from {CurrentDirectory}parent-alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Input;

public class testPrntAltInp
  : testRefPrntAltInp
  , ItestPrntAltInp
{
  public decimal? AsNumber { get; set; }
  public ItestPrntAltInpObject? As_PrntAltInp { get; set; }
}

public class testPrntAltInpObject
  : testRefPrntAltInpObject
  , ItestPrntAltInpObject
{

  public testPrntAltInpObject
    ( decimal parent
    ) : base(parent)
  {
  }
}

public class testRefPrntAltInp
  : GqlpEncoderBase
  , ItestRefPrntAltInp
{
  public string? AsString { get; set; }
  public ItestRefPrntAltInpObject? As_RefPrntAltInp { get; set; }
}

public class testRefPrntAltInpObject
  : GqlpEncoderBase
  , ItestRefPrntAltInpObject
{
  public decimal Parent { get; set; }

  public testRefPrntAltInpObject
    ( decimal parent
    )
  {
    Parent = parent;
  }
}
