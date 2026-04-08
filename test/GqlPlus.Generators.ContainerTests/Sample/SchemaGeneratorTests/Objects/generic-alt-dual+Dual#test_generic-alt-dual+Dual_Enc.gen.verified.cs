//HintName: test_generic-alt-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Dual;

public class testGnrcAltDualDual
  : GqlpEncoderBase
  , ItestGnrcAltDualDual
{
  public ItestRefGnrcAltDualDual<ItestAltGnrcAltDualDual>? AsRefGnrcAltDualDual { get; set; }
  public ItestGnrcAltDualDualObject? As_GnrcAltDualDual { get; set; }
}

public class testGnrcAltDualDualObject
  : GqlpEncoderBase
  , ItestGnrcAltDualDualObject
{

  public testGnrcAltDualDualObject
    ()
  {
  }
}

public class testRefGnrcAltDualDual<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltDualDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltDualDualObject<TRef>? As_RefGnrcAltDualDual { get; set; }
}

public class testRefGnrcAltDualDualObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltDualDualObject<TRef>
{

  public testRefGnrcAltDualDualObject
    ()
  {
  }
}

public class testAltGnrcAltDualDual
  : GqlpEncoderBase
  , ItestAltGnrcAltDualDual
{
  public string? AsString { get; set; }
  public ItestAltGnrcAltDualDualObject? As_AltGnrcAltDualDual { get; set; }
}

public class testAltGnrcAltDualDualObject
  : GqlpEncoderBase
  , ItestAltGnrcAltDualDualObject
{
  public decimal Alt { get; set; }

  public testAltGnrcAltDualDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
