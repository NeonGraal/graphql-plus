//HintName: test_generic-parent-string-dom+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Output;

public class testGnrcPrntStrDomOutp
  : testFieldGnrcPrntStrDomOutp<ItestDomGnrcPrntStrDomOutp>
  , ItestGnrcPrntStrDomOutp
{
  public ItestGnrcPrntStrDomOutpObject? As_GnrcPrntStrDomOutp { get; set; }
}

public class testGnrcPrntStrDomOutpObject
  : testFieldGnrcPrntStrDomOutpObject<ItestDomGnrcPrntStrDomOutp>
  , ItestGnrcPrntStrDomOutpObject
{

  public testGnrcPrntStrDomOutpObject
    ( ItestDomGnrcPrntStrDomOutp field
    ) : base(field)
  {
  }
}

public class testFieldGnrcPrntStrDomOutp<TRef>
  : GqlpEncoderBase
  , ItestFieldGnrcPrntStrDomOutp<TRef>
{
  public ItestFieldGnrcPrntStrDomOutpObject<TRef>? As_FieldGnrcPrntStrDomOutp { get; set; }
}

public class testFieldGnrcPrntStrDomOutpObject<TRef>
  : GqlpEncoderBase
  , ItestFieldGnrcPrntStrDomOutpObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntStrDomOutpObject
    ( TRef field
    )
  {
    Field = field;
  }
}

public class testDomGnrcPrntStrDomOutp
  : GqlpDomainString
  , ItestDomGnrcPrntStrDomOutp
{
}
