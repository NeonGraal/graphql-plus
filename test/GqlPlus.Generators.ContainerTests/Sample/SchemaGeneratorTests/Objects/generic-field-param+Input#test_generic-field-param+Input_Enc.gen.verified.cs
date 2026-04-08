//HintName: test_generic-field-param+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

public class testGnrcFieldParamInp
  : GqlpEncoderBase
  , ItestGnrcFieldParamInp
{
  public ItestGnrcFieldParamInpObject? As_GnrcFieldParamInp { get; set; }
}

public class testGnrcFieldParamInpObject
  : GqlpEncoderBase
  , ItestGnrcFieldParamInpObject
{
  public ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> Field { get; set; }

  public testGnrcFieldParamInpObject
    ( ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> field
    )
  {
    Field = field;
  }
}

public class testRefGnrcFieldParamInp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcFieldParamInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcFieldParamInpObject<TRef>? As_RefGnrcFieldParamInp { get; set; }
}

public class testRefGnrcFieldParamInpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcFieldParamInpObject<TRef>
{

  public testRefGnrcFieldParamInpObject
    ()
  {
  }
}

public class testAltGnrcFieldParamInp
  : GqlpEncoderBase
  , ItestAltGnrcFieldParamInp
{
  public string? AsString { get; set; }
  public ItestAltGnrcFieldParamInpObject? As_AltGnrcFieldParamInp { get; set; }
}

public class testAltGnrcFieldParamInpObject
  : GqlpEncoderBase
  , ItestAltGnrcFieldParamInpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcFieldParamInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
