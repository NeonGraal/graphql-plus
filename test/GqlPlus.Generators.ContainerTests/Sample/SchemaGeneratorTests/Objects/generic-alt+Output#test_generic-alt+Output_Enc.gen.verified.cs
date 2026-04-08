//HintName: test_generic-alt+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_Output;

public class testGnrcAltOutp<TType>
  : GqlpEncoderBase
  , ItestGnrcAltOutp<TType>
{
  public TType? Astype { get; set; }
  public ItestGnrcAltOutpObject<TType>? As_GnrcAltOutp { get; set; }
}

public class testGnrcAltOutpObject<TType>
  : GqlpEncoderBase
  , ItestGnrcAltOutpObject<TType>
{

  public testGnrcAltOutpObject
    ()
  {
  }
}
