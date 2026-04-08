//HintName: test_generic-field-param+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

public class testGnrcFieldParamDual
  : GqlpEncoderBase
  , ItestGnrcFieldParamDual
{
  public ItestGnrcFieldParamDualObject? As_GnrcFieldParamDual { get; set; }
}

public class testGnrcFieldParamDualObject
  : GqlpEncoderBase
  , ItestGnrcFieldParamDualObject
{
  public ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> Field { get; set; }

  public testGnrcFieldParamDualObject
    ( ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> field
    )
  {
    Field = field;
  }
}

public class testRefGnrcFieldParamDual<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcFieldParamDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcFieldParamDualObject<TRef>? As_RefGnrcFieldParamDual { get; set; }
}

public class testRefGnrcFieldParamDualObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcFieldParamDualObject<TRef>
{

  public testRefGnrcFieldParamDualObject
    ()
  {
  }
}

public class testAltGnrcFieldParamDual
  : GqlpEncoderBase
  , ItestAltGnrcFieldParamDual
{
  public string? AsString { get; set; }
  public ItestAltGnrcFieldParamDualObject? As_AltGnrcFieldParamDual { get; set; }
}

public class testAltGnrcFieldParamDualObject
  : GqlpEncoderBase
  , ItestAltGnrcFieldParamDualObject
{
  public decimal Alt { get; set; }

  public testAltGnrcFieldParamDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
