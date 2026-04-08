//HintName: test_generic-parent-string-dom+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Input;

public class testGnrcPrntStrDomInp
  : testFieldGnrcPrntStrDomInp<ItestDomGnrcPrntStrDomInp>
  , ItestGnrcPrntStrDomInp
{
  public ItestGnrcPrntStrDomInpObject? As_GnrcPrntStrDomInp { get; set; }
}

public class testGnrcPrntStrDomInpObject
  : testFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp>
  , ItestGnrcPrntStrDomInpObject
{

  public testGnrcPrntStrDomInpObject
    ( ItestDomGnrcPrntStrDomInp field
    ) : base(field)
  {
  }
}

public class testFieldGnrcPrntStrDomInp<TRef>
  : GqlpEncoderBase
  , ItestFieldGnrcPrntStrDomInp<TRef>
{
  public ItestFieldGnrcPrntStrDomInpObject<TRef>? As_FieldGnrcPrntStrDomInp { get; set; }
}

public class testFieldGnrcPrntStrDomInpObject<TRef>
  : GqlpEncoderBase
  , ItestFieldGnrcPrntStrDomInpObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntStrDomInpObject
    ( TRef field
    )
  {
    Field = field;
  }
}

public class testDomGnrcPrntStrDomInp
  : GqlpDomainString
  , ItestDomGnrcPrntStrDomInp
{
}
