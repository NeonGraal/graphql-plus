//HintName: test_generic-alt-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Output;

public class testGnrcAltDualOutp
  : GqlpEncoderBase
  , ItestGnrcAltDualOutp
{
  public ItestRefGnrcAltDualOutp<ItestAltGnrcAltDualOutp>? AsRefGnrcAltDualOutp { get; set; }
  public ItestGnrcAltDualOutpObject? As_GnrcAltDualOutp { get; set; }
}

public class testGnrcAltDualOutpObject
  : GqlpEncoderBase
  , ItestGnrcAltDualOutpObject
{

  public testGnrcAltDualOutpObject
    ()
  {
  }
}

public class testRefGnrcAltDualOutp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltDualOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltDualOutpObject<TRef>? As_RefGnrcAltDualOutp { get; set; }
}

public class testRefGnrcAltDualOutpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltDualOutpObject<TRef>
{

  public testRefGnrcAltDualOutpObject
    ()
  {
  }
}

public class testAltGnrcAltDualOutp
  : GqlpEncoderBase
  , ItestAltGnrcAltDualOutp
{
  public string? AsString { get; set; }
  public ItestAltGnrcAltDualOutpObject? As_AltGnrcAltDualOutp { get; set; }
}

public class testAltGnrcAltDualOutpObject
  : GqlpEncoderBase
  , ItestAltGnrcAltDualOutpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcAltDualOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
