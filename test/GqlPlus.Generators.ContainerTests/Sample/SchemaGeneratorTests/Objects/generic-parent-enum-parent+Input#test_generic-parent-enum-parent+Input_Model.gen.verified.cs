//HintName: test_generic-parent-enum-parent+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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
  : GqlpModelBase
  , ItestFieldGnrcPrntEnumPrntInp<TRef>
{
  public ItestFieldGnrcPrntEnumPrntInpObject<TRef>? As_FieldGnrcPrntEnumPrntInp { get; set; }
}

public class testFieldGnrcPrntEnumPrntInpObject<TRef>
  : GqlpModelBase
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
