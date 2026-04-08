//HintName: test_alt+Output_Enc.gen.cs
// Generated from {CurrentDirectory}alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Output;

public class testAltOutp
  : GqlpEncoderBase
  , ItestAltOutp
{
  public ItestAltAltOutp? AsAltAltOutp { get; set; }
  public ItestAltOutpObject? As_AltOutp { get; set; }
}

public class testAltOutpObject
  : GqlpEncoderBase
  , ItestAltOutpObject
{

  public testAltOutpObject
    ()
  {
  }
}

public class testAltAltOutp
  : GqlpEncoderBase
  , ItestAltAltOutp
{
  public string? AsString { get; set; }
  public ItestAltAltOutpObject? As_AltAltOutp { get; set; }
}

public class testAltAltOutpObject
  : GqlpEncoderBase
  , ItestAltAltOutpObject
{
  public decimal Alt { get; set; }

  public testAltAltOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
