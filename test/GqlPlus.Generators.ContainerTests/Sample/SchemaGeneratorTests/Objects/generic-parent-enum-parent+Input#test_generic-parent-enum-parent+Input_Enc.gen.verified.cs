//HintName: test_generic-parent-enum-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Input;

public class testGnrcPrntEnumPrntInp
  : testFieldGnrcPrntEnumPrntInp<testEnumGnrcPrntEnumPrntInp>
  , ItestGnrcPrntEnumPrntInp
{
  public ItestGnrcPrntEnumPrntInpObject? As_GnrcPrntEnumPrntInp { get; set; }
}

public class testGnrcPrntEnumPrntInpObject
  : testFieldGnrcPrntEnumPrntInpObject<testEnumGnrcPrntEnumPrntInp>
  , ItestGnrcPrntEnumPrntInpObject
{

  public testGnrcPrntEnumPrntInpObject
    ( testEnumGnrcPrntEnumPrntInp field
    ) : base(field)
  {
  }
}

public class testFieldGnrcPrntEnumPrntInp<TRef>
  : GqlpEncoderBase
  , ItestFieldGnrcPrntEnumPrntInp<TRef>
{
  public ItestFieldGnrcPrntEnumPrntInpObject<TRef>? As_FieldGnrcPrntEnumPrntInp { get; set; }
}

public class testFieldGnrcPrntEnumPrntInpObject<TRef>
  : GqlpEncoderBase
  , ItestFieldGnrcPrntEnumPrntInpObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntEnumPrntInpObject
    ( TRef field
    )
  {
    Field = field;
  }
}

public enum testEnumGnrcPrntEnumPrntInp
{
  gnrcPrntEnumPrntInpParent = testParentGnrcPrntEnumPrntInp.gnrcPrntEnumPrntInpParent,
  gnrcPrntEnumPrntInpLabel,
}

public enum testParentGnrcPrntEnumPrntInp
{
  gnrcPrntEnumPrntInpParent,
}
