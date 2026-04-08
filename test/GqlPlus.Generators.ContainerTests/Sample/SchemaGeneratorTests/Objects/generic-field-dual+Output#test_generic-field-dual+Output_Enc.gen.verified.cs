//HintName: test_generic-field-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

public class testGnrcFieldDualOutp
  : GqlpEncoderBase
  , ItestGnrcFieldDualOutp
{
  public ItestGnrcFieldDualOutpObject? As_GnrcFieldDualOutp { get; set; }
}

public class testGnrcFieldDualOutpObject
  : GqlpEncoderBase
  , ItestGnrcFieldDualOutpObject
{
  public ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> Field { get; set; }

  public testGnrcFieldDualOutpObject
    ( ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> field
    )
  {
    Field = field;
  }
}

public class testRefGnrcFieldDualOutp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcFieldDualOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcFieldDualOutpObject<TRef>? As_RefGnrcFieldDualOutp { get; set; }
}

public class testRefGnrcFieldDualOutpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcFieldDualOutpObject<TRef>
{

  public testRefGnrcFieldDualOutpObject
    ()
  {
  }
}

public class testAltGnrcFieldDualOutp
  : GqlpEncoderBase
  , ItestAltGnrcFieldDualOutp
{
  public string? AsString { get; set; }
  public ItestAltGnrcFieldDualOutpObject? As_AltGnrcFieldDualOutp { get; set; }
}

public class testAltGnrcFieldDualOutpObject
  : GqlpEncoderBase
  , ItestAltGnrcFieldDualOutpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcFieldDualOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
