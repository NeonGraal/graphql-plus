//HintName: test_parent-descr+Output_Enc.gen.cs
// Generated from {CurrentDirectory}parent-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Output;

public class testPrntDescrOutp
  : testRefPrntDescrOutp
  , ItestPrntDescrOutp
{
  public ItestPrntDescrOutpObject? As_PrntDescrOutp { get; set; }
}

public class testPrntDescrOutpObject
  : testRefPrntDescrOutpObject
  , ItestPrntDescrOutpObject
{

  public testPrntDescrOutpObject
    ( decimal parent
    ) : base(parent)
  {
  }
}

public class testRefPrntDescrOutp
  : GqlpEncoderBase
  , ItestRefPrntDescrOutp
{
  public string? AsString { get; set; }
  public ItestRefPrntDescrOutpObject? As_RefPrntDescrOutp { get; set; }
}

public class testRefPrntDescrOutpObject
  : GqlpEncoderBase
  , ItestRefPrntDescrOutpObject
{
  public decimal Parent { get; set; }

  public testRefPrntDescrOutpObject
    ( decimal parent
    )
  {
    Parent = parent;
  }
}
