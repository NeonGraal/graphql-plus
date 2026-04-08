//HintName: test_generic-parent-enum-child+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Input;

public class testGnrcPrntEnumChildInp
  : testFieldGnrcPrntEnumChildInp<testParentGnrcPrntEnumChildInp>
  , ItestGnrcPrntEnumChildInp
{
  public ItestGnrcPrntEnumChildInpObject? As_GnrcPrntEnumChildInp { get; set; }
}

public class testGnrcPrntEnumChildInpObject
  : testFieldGnrcPrntEnumChildInpObject<testParentGnrcPrntEnumChildInp>
  , ItestGnrcPrntEnumChildInpObject
{

  public testGnrcPrntEnumChildInpObject
    ( testParentGnrcPrntEnumChildInp field
    ) : base(field)
  {
  }
}

public class testFieldGnrcPrntEnumChildInp<TRef>
  : GqlpEncoderBase
  , ItestFieldGnrcPrntEnumChildInp<TRef>
{
  public ItestFieldGnrcPrntEnumChildInpObject<TRef>? As_FieldGnrcPrntEnumChildInp { get; set; }
}

public class testFieldGnrcPrntEnumChildInpObject<TRef>
  : GqlpEncoderBase
  , ItestFieldGnrcPrntEnumChildInpObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntEnumChildInpObject
    ( TRef field
    )
  {
    Field = field;
  }
}

public enum testEnumGnrcPrntEnumChildInp
{
  gnrcPrntEnumChildInpParent = testParentGnrcPrntEnumChildInp.gnrcPrntEnumChildInpParent,
  gnrcPrntEnumChildInpLabel,
}

public enum testParentGnrcPrntEnumChildInp
{
  gnrcPrntEnumChildInpParent,
}
