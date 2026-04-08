//HintName: test_generic-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Input;

public class testGnrcPrntInp<TType>
  : GqlpEncoderBase
  , ItestGnrcPrntInp<TType>
{
  public TType? As_Parent { get; set; }
  public ItestGnrcPrntInpObject<TType>? As_GnrcPrntInp { get; set; }
}

public class testGnrcPrntInpObject<TType>
  : GqlpEncoderBase
  , ItestGnrcPrntInpObject<TType>
{

  public testGnrcPrntInpObject
    ()
  {
  }
}
