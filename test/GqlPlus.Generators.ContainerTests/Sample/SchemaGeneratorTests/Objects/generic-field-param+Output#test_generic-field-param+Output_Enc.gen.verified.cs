//HintName: test_generic-field-param+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Output;

public class testGnrcFieldParamOutp
  : GqlpEncoderBase
  , ItestGnrcFieldParamOutp
{
  public ItestGnrcFieldParamOutpObject? As_GnrcFieldParamOutp { get; set; }
}

public class testGnrcFieldParamOutpObject
  : GqlpEncoderBase
  , ItestGnrcFieldParamOutpObject
{
  public ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp> Field { get; set; }

  public testGnrcFieldParamOutpObject
    ( ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp> field
    )
  {
    Field = field;
  }
}

public class testRefGnrcFieldParamOutp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcFieldParamOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcFieldParamOutpObject<TRef>? As_RefGnrcFieldParamOutp { get; set; }
}

public class testRefGnrcFieldParamOutpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcFieldParamOutpObject<TRef>
{

  public testRefGnrcFieldParamOutpObject
    ()
  {
  }
}

public class testAltGnrcFieldParamOutp
  : GqlpEncoderBase
  , ItestAltGnrcFieldParamOutp
{
  public string? AsString { get; set; }
  public ItestAltGnrcFieldParamOutpObject? As_AltGnrcFieldParamOutp { get; set; }
}

public class testAltGnrcFieldParamOutpObject
  : GqlpEncoderBase
  , ItestAltGnrcFieldParamOutpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcFieldParamOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
