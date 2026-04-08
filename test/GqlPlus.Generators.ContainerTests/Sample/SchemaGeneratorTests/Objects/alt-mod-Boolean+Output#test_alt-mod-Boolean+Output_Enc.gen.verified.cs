//HintName: test_alt-mod-Boolean+Output_Enc.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Output;

public class testAltModBoolOutp
  : GqlpEncoderBase
  , ItestAltModBoolOutp
{
  public IDictionary<bool, ItestAltAltModBoolOutp>? AsAltAltModBoolOutp { get; set; }
  public ItestAltModBoolOutpObject? As_AltModBoolOutp { get; set; }
}

public class testAltModBoolOutpObject
  : GqlpEncoderBase
  , ItestAltModBoolOutpObject
{

  public testAltModBoolOutpObject
    ()
  {
  }
}

public class testAltAltModBoolOutp
  : GqlpEncoderBase
  , ItestAltAltModBoolOutp
{
  public string? AsString { get; set; }
  public ItestAltAltModBoolOutpObject? As_AltAltModBoolOutp { get; set; }
}

public class testAltAltModBoolOutpObject
  : GqlpEncoderBase
  , ItestAltAltModBoolOutpObject
{
  public decimal Alt { get; set; }

  public testAltAltModBoolOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
