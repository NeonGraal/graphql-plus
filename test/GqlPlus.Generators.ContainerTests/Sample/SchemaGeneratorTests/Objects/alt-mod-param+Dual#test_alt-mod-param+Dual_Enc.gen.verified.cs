//HintName: test_alt-mod-param+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Dual;

public class testAltModParamDual<TMod>
  : GqlpEncoderBase
  , ItestAltModParamDual<TMod>
{
  public IDictionary<TMod, ItestAltAltModParamDual>? AsAltAltModParamDual { get; set; }
  public ItestAltModParamDualObject<TMod>? As_AltModParamDual { get; set; }
}

public class testAltModParamDualObject<TMod>
  : GqlpEncoderBase
  , ItestAltModParamDualObject<TMod>
{

  public testAltModParamDualObject
    ()
  {
  }
}

public class testAltAltModParamDual
  : GqlpEncoderBase
  , ItestAltAltModParamDual
{
  public string? AsString { get; set; }
  public ItestAltAltModParamDualObject? As_AltAltModParamDual { get; set; }
}

public class testAltAltModParamDualObject
  : GqlpEncoderBase
  , ItestAltAltModParamDualObject
{
  public decimal Alt { get; set; }

  public testAltAltModParamDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
