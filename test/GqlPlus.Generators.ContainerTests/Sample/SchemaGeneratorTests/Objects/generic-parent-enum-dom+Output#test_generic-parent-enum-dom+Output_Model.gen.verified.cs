//HintName: test_generic-parent-enum-dom+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Output;

public class testGnrcPrntEnumDomOutp
  : testFieldGnrcPrntEnumDomOutp<ItestDomGnrcPrntEnumDomOutp>
  , ItestGnrcPrntEnumDomOutp
{
  public ItestGnrcPrntEnumDomOutpObject? As_GnrcPrntEnumDomOutp { get; set; }
}

public class testGnrcPrntEnumDomOutpObject
  : testFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>
  , ItestGnrcPrntEnumDomOutpObject
{

  public testGnrcPrntEnumDomOutpObject
    ( ItestDomGnrcPrntEnumDomOutp field
    ) : base(field)
  {
  }
}

public class testFieldGnrcPrntEnumDomOutp<TRef>
  : GqlpModelBase
  , ItestFieldGnrcPrntEnumDomOutp<TRef>
{
  public ItestFieldGnrcPrntEnumDomOutpObject<TRef>? As_FieldGnrcPrntEnumDomOutp { get; set; }
}

public class testFieldGnrcPrntEnumDomOutpObject<TRef>
  : GqlpModelBase
  , ItestFieldGnrcPrntEnumDomOutpObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntEnumDomOutpObject
    ( TRef field
    )
  {
    Field = field;
  }
}

public class testDomGnrcPrntEnumDomOutp
  : GqlpDomainEnum
  , ItestDomGnrcPrntEnumDomOutp
{
  public new testEnumGnrcPrntEnumDomOutp? Value { get; set; }
}
