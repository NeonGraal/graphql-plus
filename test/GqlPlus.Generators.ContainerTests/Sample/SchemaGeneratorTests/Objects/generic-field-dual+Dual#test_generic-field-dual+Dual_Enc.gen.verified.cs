//HintName: test_generic-field-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Dual;

public class testGnrcFieldDualDual
  : GqlpEncoderBase
  , ItestGnrcFieldDualDual
{
  public ItestGnrcFieldDualDualObject? As_GnrcFieldDualDual { get; set; }
}

public class testGnrcFieldDualDualObject
  : GqlpEncoderBase
  , ItestGnrcFieldDualDualObject
{
  public ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> Field { get; set; }

  public testGnrcFieldDualDualObject
    ( ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> field
    )
  {
    Field = field;
  }
}

public class testRefGnrcFieldDualDual<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcFieldDualDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcFieldDualDualObject<TRef>? As_RefGnrcFieldDualDual { get; set; }
}

public class testRefGnrcFieldDualDualObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcFieldDualDualObject<TRef>
{

  public testRefGnrcFieldDualDualObject
    ()
  {
  }
}

public class testAltGnrcFieldDualDual
  : GqlpEncoderBase
  , ItestAltGnrcFieldDualDual
{
  public string? AsString { get; set; }
  public ItestAltGnrcFieldDualDualObject? As_AltGnrcFieldDualDual { get; set; }
}

public class testAltGnrcFieldDualDualObject
  : GqlpEncoderBase
  , ItestAltGnrcFieldDualDualObject
{
  public decimal Alt { get; set; }

  public testAltGnrcFieldDualDualObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
