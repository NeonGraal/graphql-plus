//HintName: test_generic-parent-descr+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_descr_Output;

public class testGnrcPrntDescrOutp<TType>
  : GqlpEncoderBase
  , ItestGnrcPrntDescrOutp<TType>
{
  public TType? As_Parent { get; set; }
  public ItestGnrcPrntDescrOutpObject<TType>? As_GnrcPrntDescrOutp { get; set; }
}

public class testGnrcPrntDescrOutpObject<TType>
  : GqlpEncoderBase
  , ItestGnrcPrntDescrOutpObject<TType>
{

  public testGnrcPrntDescrOutpObject
    ()
  {
  }
}
