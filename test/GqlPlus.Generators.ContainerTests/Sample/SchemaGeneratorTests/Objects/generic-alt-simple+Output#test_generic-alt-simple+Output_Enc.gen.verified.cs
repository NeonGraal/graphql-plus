//HintName: test_generic-alt-simple+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Output;

public class testGnrcAltSmplOutp
  : GqlpEncoderBase
  , ItestGnrcAltSmplOutp
{
  public ItestRefGnrcAltSmplOutp<string>? AsRefGnrcAltSmplOutp { get; set; }
  public ItestGnrcAltSmplOutpObject? As_GnrcAltSmplOutp { get; set; }
}

public class testGnrcAltSmplOutpObject
  : GqlpEncoderBase
  , ItestGnrcAltSmplOutpObject
{

  public testGnrcAltSmplOutpObject
    ()
  {
  }
}

public class testRefGnrcAltSmplOutp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltSmplOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltSmplOutpObject<TRef>? As_RefGnrcAltSmplOutp { get; set; }
}

public class testRefGnrcAltSmplOutpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltSmplOutpObject<TRef>
{

  public testRefGnrcAltSmplOutpObject
    ()
  {
  }
}
