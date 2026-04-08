//HintName: test_generic-alt-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Input;

public class testGnrcAltDualInp
  : GqlpEncoderBase
  , ItestGnrcAltDualInp
{
  public ItestRefGnrcAltDualInp<ItestAltGnrcAltDualInp>? AsRefGnrcAltDualInp { get; set; }
  public ItestGnrcAltDualInpObject? As_GnrcAltDualInp { get; set; }
}

public class testGnrcAltDualInpObject
  : GqlpEncoderBase
  , ItestGnrcAltDualInpObject
{

  public testGnrcAltDualInpObject
    ()
  {
  }
}

public class testRefGnrcAltDualInp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltDualInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltDualInpObject<TRef>? As_RefGnrcAltDualInp { get; set; }
}

public class testRefGnrcAltDualInpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltDualInpObject<TRef>
{

  public testRefGnrcAltDualInpObject
    ()
  {
  }
}

public class testAltGnrcAltDualInp
  : GqlpEncoderBase
  , ItestAltGnrcAltDualInp
{
  public string? AsString { get; set; }
  public ItestAltGnrcAltDualInpObject? As_AltGnrcAltDualInp { get; set; }
}

public class testAltGnrcAltDualInpObject
  : GqlpEncoderBase
  , ItestAltGnrcAltDualInpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcAltDualInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
