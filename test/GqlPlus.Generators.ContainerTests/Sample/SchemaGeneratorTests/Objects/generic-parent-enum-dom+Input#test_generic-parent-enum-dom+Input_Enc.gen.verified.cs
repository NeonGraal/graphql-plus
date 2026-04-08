//HintName: test_generic-parent-enum-dom+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Input;

public class testGnrcPrntEnumDomInp
  : testFieldGnrcPrntEnumDomInp<ItestDomGnrcPrntEnumDomInp>
  , ItestGnrcPrntEnumDomInp
{
  public ItestGnrcPrntEnumDomInpObject? As_GnrcPrntEnumDomInp { get; set; }
}

public class testGnrcPrntEnumDomInpObject
  : testFieldGnrcPrntEnumDomInpObject<ItestDomGnrcPrntEnumDomInp>
  , ItestGnrcPrntEnumDomInpObject
{

  public testGnrcPrntEnumDomInpObject
    ( ItestDomGnrcPrntEnumDomInp field
    ) : base(field)
  {
  }
}

public class testFieldGnrcPrntEnumDomInp<TRef>
  : GqlpEncoderBase
  , ItestFieldGnrcPrntEnumDomInp<TRef>
{
  public ItestFieldGnrcPrntEnumDomInpObject<TRef>? As_FieldGnrcPrntEnumDomInp { get; set; }
}

public class testFieldGnrcPrntEnumDomInpObject<TRef>
  : GqlpEncoderBase
  , ItestFieldGnrcPrntEnumDomInpObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntEnumDomInpObject
    ( TRef field
    )
  {
    Field = field;
  }
}

public enum testEnumGnrcPrntEnumDomInp
{
  gnrcPrntEnumDomInpLabel,
  gnrcPrntEnumDomInpOther,
}

public class testDomGnrcPrntEnumDomInp
  : GqlpDomainEnum
  , ItestDomGnrcPrntEnumDomInp
{
}
