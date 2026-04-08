//HintName: test_alt+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Dual;

public class testAltDual
  : GqlpEncoderBase
  , ItestAltDual
{
  public ItestAltAltDual? AsAltAltDual { get; set; }
  public ItestAltDualObject? As_AltDual { get; set; }
}

public class testAltDualObject
  : GqlpEncoderBase
  , ItestAltDualObject
{

  public testAltDualObject
    ()
  {
  }
}

public class testAltAltDual
  : GqlpEncoderBase
  , ItestAltAltDual
{
  public string? AsString { get; set; }
  public ItestAltAltDualObject? As_AltAltDual { get; set; }
}

public class testAltAltDualObject
  : GqlpEncoderBase
  , ItestAltAltDualObject
{
  public decimal Alt { get; set; }

  public testAltAltDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
