//HintName: test_generic-alt-arg+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Output;

public class testGnrcAltArgOutp<TType>
  : GqlpEncoderBase
  , ItestGnrcAltArgOutp<TType>
{
  public ItestRefGnrcAltArgOutp<TType>? AsRefGnrcAltArgOutp { get; set; }
  public ItestGnrcAltArgOutpObject<TType>? As_GnrcAltArgOutp { get; set; }
}

public class testGnrcAltArgOutpObject<TType>
  : GqlpEncoderBase
  , ItestGnrcAltArgOutpObject<TType>
{

  public testGnrcAltArgOutpObject
    ()
  {
  }
}

public class testRefGnrcAltArgOutp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltArgOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltArgOutpObject<TRef>? As_RefGnrcAltArgOutp { get; set; }
}

public class testRefGnrcAltArgOutpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltArgOutpObject<TRef>
{

  public testRefGnrcAltArgOutpObject
    ()
  {
  }
}
