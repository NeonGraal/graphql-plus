//HintName: test_generic-parent-enum-child+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Dual;

public class testGnrcPrntEnumChildDual
  : testFieldGnrcPrntEnumChildDual<testParentGnrcPrntEnumChildDual>
  , ItestGnrcPrntEnumChildDual
{
  public ItestGnrcPrntEnumChildDualObject? As_GnrcPrntEnumChildDual { get; set; }
}

public class testGnrcPrntEnumChildDualObject
  : testFieldGnrcPrntEnumChildDualObject<testParentGnrcPrntEnumChildDual>
  , ItestGnrcPrntEnumChildDualObject
{

  public testGnrcPrntEnumChildDualObject
    ( testParentGnrcPrntEnumChildDual field
    ) : base(field)
  {
  }
}

public class testFieldGnrcPrntEnumChildDual<TRef>
  : GqlpEncoderBase
  , ItestFieldGnrcPrntEnumChildDual<TRef>
{
  public ItestFieldGnrcPrntEnumChildDualObject<TRef>? As_FieldGnrcPrntEnumChildDual { get; set; }
}

public class testFieldGnrcPrntEnumChildDualObject<TRef>
  : GqlpEncoderBase
  , ItestFieldGnrcPrntEnumChildDualObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntEnumChildDualObject
    ( TRef field
    )
  {
    Field = field;
  }
}

public enum testEnumGnrcPrntEnumChildDual
{
  gnrcPrntEnumChildDualParent = testParentGnrcPrntEnumChildDual.gnrcPrntEnumChildDualParent,
  gnrcPrntEnumChildDualLabel,
}

public enum testParentGnrcPrntEnumChildDual
{
  gnrcPrntEnumChildDualParent,
}
