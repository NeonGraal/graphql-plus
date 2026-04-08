//HintName: test_generic-parent-descr+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_descr_Input;

public class testGnrcPrntDescrInp<TType>
  : GqlpEncoderBase
  , ItestGnrcPrntDescrInp<TType>
{
  public TType? As_Parent { get; set; }
  public ItestGnrcPrntDescrInpObject<TType>? As_GnrcPrntDescrInp { get; set; }
}

public class testGnrcPrntDescrInpObject<TType>
  : GqlpEncoderBase
  , ItestGnrcPrntDescrInpObject<TType>
{

  public testGnrcPrntDescrInpObject
    ()
  {
  }
}
