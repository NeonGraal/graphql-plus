//HintName: test_generic-parent-enum-dom+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Dual;

public class testGnrcPrntEnumDomDual
  : testFieldGnrcPrntEnumDomDual<ItestDomGnrcPrntEnumDomDual>
  , ItestGnrcPrntEnumDomDual
{
  public ItestGnrcPrntEnumDomDualObject? As_GnrcPrntEnumDomDual { get; set; }
}

public class testGnrcPrntEnumDomDualObject
  : testFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual>
  , ItestGnrcPrntEnumDomDualObject
{

  public testGnrcPrntEnumDomDualObject
    ( ItestDomGnrcPrntEnumDomDual field
    ) : base(field)
  {
  }
}

public class testFieldGnrcPrntEnumDomDual<TRef>
  : GqlpEncoderBase
  , ItestFieldGnrcPrntEnumDomDual<TRef>
{
  public ItestFieldGnrcPrntEnumDomDualObject<TRef>? As_FieldGnrcPrntEnumDomDual { get; set; }
}

public class testFieldGnrcPrntEnumDomDualObject<TRef>
  : GqlpEncoderBase
  , ItestFieldGnrcPrntEnumDomDualObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntEnumDomDualObject
    ( TRef field
    )
  {
    Field = field;
  }
}

public enum testEnumGnrcPrntEnumDomDual
{
  gnrcPrntEnumDomDualLabel,
  gnrcPrntEnumDomDualOther,
}

public class testDomGnrcPrntEnumDomDual
  : GqlpDomainEnum
  , ItestDomGnrcPrntEnumDomDual
{
}
