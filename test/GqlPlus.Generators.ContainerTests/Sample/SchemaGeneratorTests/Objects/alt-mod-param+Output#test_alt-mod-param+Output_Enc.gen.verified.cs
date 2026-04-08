//HintName: test_alt-mod-param+Output_Enc.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Output;

public class testAltModParamOutp<TMod>
  : GqlpEncoderBase
  , ItestAltModParamOutp<TMod>
{
  public IDictionary<TMod, ItestAltAltModParamOutp>? AsAltAltModParamOutp { get; set; }
  public ItestAltModParamOutpObject<TMod>? As_AltModParamOutp { get; set; }
}

public class testAltModParamOutpObject<TMod>
  : GqlpEncoderBase
  , ItestAltModParamOutpObject<TMod>
{

  public testAltModParamOutpObject
    ()
  {
  }
}

public class testAltAltModParamOutp
  : GqlpEncoderBase
  , ItestAltAltModParamOutp
{
  public string? AsString { get; set; }
  public ItestAltAltModParamOutpObject? As_AltAltModParamOutp { get; set; }
}

public class testAltAltModParamOutpObject
  : GqlpEncoderBase
  , ItestAltAltModParamOutpObject
{
  public decimal Alt { get; set; }

  public testAltAltModParamOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
