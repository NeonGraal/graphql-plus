//HintName: test_parent-field+Input_Enc.gen.cs
// Generated from {CurrentDirectory}parent-field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Input;

public class testPrntFieldInp
  : testRefPrntFieldInp
  , ItestPrntFieldInp
{
  public ItestPrntFieldInpObject? As_PrntFieldInp { get; set; }
}

public class testPrntFieldInpObject
  : testRefPrntFieldInpObject
  , ItestPrntFieldInpObject
{
  public decimal Field { get; set; }

  public testPrntFieldInpObject
    ( decimal parent
    , decimal field
    ) : base(parent)
  {
    Field = field;
  }
}

public class testRefPrntFieldInp
  : GqlpEncoderBase
  , ItestRefPrntFieldInp
{
  public string? AsString { get; set; }
  public ItestRefPrntFieldInpObject? As_RefPrntFieldInp { get; set; }
}

public class testRefPrntFieldInpObject
  : GqlpEncoderBase
  , ItestRefPrntFieldInpObject
{
  public decimal Parent { get; set; }

  public testRefPrntFieldInpObject
    ( decimal parent
    )
  {
    Parent = parent;
  }
}
