//HintName: test_generic-parent-enum-parent+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Output;

public class testGnrcPrntEnumPrntOutp
  : testFieldGnrcPrntEnumPrntOutp<testEnumGnrcPrntEnumPrntOutp>
  , ItestGnrcPrntEnumPrntOutp
{
  public ItestGnrcPrntEnumPrntOutpObject? As_GnrcPrntEnumPrntOutp { get; set; }
}

public class testGnrcPrntEnumPrntOutpObject
  : testFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>
  , ItestGnrcPrntEnumPrntOutpObject
{

  public testGnrcPrntEnumPrntOutpObject
    ( testEnumGnrcPrntEnumPrntOutp field
    ) : base(field)
  {
  }
}

public class testFieldGnrcPrntEnumPrntOutp<TRef>
  : GqlpModelBase
  , ItestFieldGnrcPrntEnumPrntOutp<TRef>
{
  public ItestFieldGnrcPrntEnumPrntOutpObject<TRef>? As_FieldGnrcPrntEnumPrntOutp { get; set; }
}

public class testFieldGnrcPrntEnumPrntOutpObject<TRef>
  : GqlpModelBase
  , ItestFieldGnrcPrntEnumPrntOutpObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntEnumPrntOutpObject
    ( TRef field
    )
  {
    Field = field;
  }
}
