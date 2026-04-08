//HintName: test_generic-alt-param+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Output;

public class testGnrcAltParamOutp
  : GqlpEncoderBase
  , ItestGnrcAltParamOutp
{
  public ItestRefGnrcAltParamOutp<ItestAltGnrcAltParamOutp>? AsRefGnrcAltParamOutp { get; set; }
  public ItestGnrcAltParamOutpObject? As_GnrcAltParamOutp { get; set; }
}

public class testGnrcAltParamOutpObject
  : GqlpEncoderBase
  , ItestGnrcAltParamOutpObject
{

  public testGnrcAltParamOutpObject
    ()
  {
  }
}

public class testRefGnrcAltParamOutp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltParamOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltParamOutpObject<TRef>? As_RefGnrcAltParamOutp { get; set; }
}

public class testRefGnrcAltParamOutpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcAltParamOutpObject<TRef>
{

  public testRefGnrcAltParamOutpObject
    ()
  {
  }
}

public class testAltGnrcAltParamOutp
  : GqlpEncoderBase
  , ItestAltGnrcAltParamOutp
{
  public string? AsString { get; set; }
  public ItestAltGnrcAltParamOutpObject? As_AltGnrcAltParamOutp { get; set; }
}

public class testAltGnrcAltParamOutpObject
  : GqlpEncoderBase
  , ItestAltGnrcAltParamOutpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcAltParamOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
