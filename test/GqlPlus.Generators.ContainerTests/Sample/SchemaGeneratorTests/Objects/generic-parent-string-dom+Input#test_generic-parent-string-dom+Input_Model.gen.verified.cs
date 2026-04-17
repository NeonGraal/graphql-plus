//HintName: test_generic-parent-string-dom+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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
  : GqlpModelBase
  , ItestFieldGnrcPrntStrDomInp<TRef>
{
  public ItestFieldGnrcPrntStrDomInpObject<TRef>? As_FieldGnrcPrntStrDomInp { get; set; }
}

public class testFieldGnrcPrntStrDomInpObject<TRef>
  : GqlpModelBase
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
