//HintName: test_generic-parent-enum-child+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Input;

public class testGnrcPrntEnumChildInp
  : testFieldGnrcPrntEnumChildInp<testParentGnrcPrntEnumChildInp>
  , ItestGnrcPrntEnumChildInp
{
  public ItestGnrcPrntEnumChildInpObject? As_GnrcPrntEnumChildInp { get; set; }
}

public class testGnrcPrntEnumChildInpObject
  : testFieldGnrcPrntEnumChildInpObject<testParentGnrcPrntEnumChildInp>
  , ItestGnrcPrntEnumChildInpObject
{

  public testGnrcPrntEnumChildInpObject
    ( testParentGnrcPrntEnumChildInp field
    ) : base(field)
  {
  }
}

public class testFieldGnrcPrntEnumChildInp<TRef>
  : GqlpModelBase
  , ItestFieldGnrcPrntEnumChildInp<TRef>
{
  public ItestFieldGnrcPrntEnumChildInpObject<TRef>? As_FieldGnrcPrntEnumChildInp { get; set; }
}

public class testFieldGnrcPrntEnumChildInpObject<TRef>
  : GqlpModelBase
  , ItestFieldGnrcPrntEnumChildInpObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntEnumChildInpObject
    ( TRef field
    )
  {
    Field = field;
  }
}
