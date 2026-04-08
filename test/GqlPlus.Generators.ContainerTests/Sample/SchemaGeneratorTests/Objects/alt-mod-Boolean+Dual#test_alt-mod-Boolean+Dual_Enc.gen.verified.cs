//HintName: test_alt-mod-Boolean+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Dual;

public class testAltModBoolDual
  : GqlpEncoderBase
  , ItestAltModBoolDual
{
  public IDictionary<bool, ItestAltAltModBoolDual>? AsAltAltModBoolDual { get; set; }
  public ItestAltModBoolDualObject? As_AltModBoolDual { get; set; }
}

public class testAltModBoolDualObject
  : GqlpEncoderBase
  , ItestAltModBoolDualObject
{

  public testAltModBoolDualObject
    ()
  {
  }
}

public class testAltAltModBoolDual
  : GqlpEncoderBase
  , ItestAltAltModBoolDual
{
  public string? AsString { get; set; }
  public ItestAltAltModBoolDualObject? As_AltAltModBoolDual { get; set; }
}

public class testAltAltModBoolDualObject
  : GqlpEncoderBase
  , ItestAltAltModBoolDualObject
{
  public decimal Alt { get; set; }

  public testAltAltModBoolDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
