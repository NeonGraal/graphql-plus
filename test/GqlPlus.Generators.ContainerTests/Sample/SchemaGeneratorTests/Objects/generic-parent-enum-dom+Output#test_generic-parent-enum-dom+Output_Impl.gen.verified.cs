//HintName: test_generic-parent-enum-dom+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
  : GqlpModelImplementationBase
  , ItestFieldGnrcPrntEnumDomOutp<TRef>
{
  public ItestFieldGnrcPrntEnumDomOutpObject<TRef>? As_FieldGnrcPrntEnumDomOutp { get; set; }
}

public class testFieldGnrcPrntEnumDomOutpObject<TRef>
  : GqlpModelImplementationBase
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
}
