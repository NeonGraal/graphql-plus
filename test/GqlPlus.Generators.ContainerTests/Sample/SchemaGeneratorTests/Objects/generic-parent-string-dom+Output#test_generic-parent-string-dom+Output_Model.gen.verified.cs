//HintName: test_generic-parent-string-dom+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
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
  : GqlpModelImplementationBase
  , ItestFieldGnrcPrntStrDomOutp<TRef>
{
  public ItestFieldGnrcPrntStrDomOutpObject<TRef>? As_FieldGnrcPrntStrDomOutp { get; set; }
}

public class testFieldGnrcPrntStrDomOutpObject<TRef>
  : GqlpModelImplementationBase
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
