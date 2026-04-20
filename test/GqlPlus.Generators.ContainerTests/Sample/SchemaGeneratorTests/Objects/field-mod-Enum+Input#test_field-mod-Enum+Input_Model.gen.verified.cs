//HintName: test_field-mod-Enum+Input_Model.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Input;

public class testFieldModEnumInp
  : GqlpModelBase
  , ItestFieldModEnumInp
{
  public ItestFieldModEnumInpObject? As_FieldModEnumInp { get; set; }
}

public class testFieldModEnumInpObject
  : GqlpModelBase
  , ItestFieldModEnumInpObject
{
  public IDictionary<testEnumFieldModEnumInp, string> Field { get; set; }

  public testFieldModEnumInpObject
    ( IDictionary<testEnumFieldModEnumInp, string> pfield
    )
  {
    Field = pfield;
  }
}
