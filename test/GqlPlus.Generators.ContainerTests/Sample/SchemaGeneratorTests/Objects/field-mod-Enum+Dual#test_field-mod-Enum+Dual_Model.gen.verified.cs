//HintName: test_field-mod-Enum+Dual_Model.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Dual;

public class testFieldModEnumDual
  : GqlpModelBase
  , ItestFieldModEnumDual
{
  public ItestFieldModEnumDualObject? As_FieldModEnumDual { get; set; }
}

public class testFieldModEnumDualObject
  : GqlpModelBase
  , ItestFieldModEnumDualObject
{
  public IDictionary<testEnumFieldModEnumDual, string> Field { get; set; }

  public testFieldModEnumDualObject
    ( IDictionary<testEnumFieldModEnumDual, string> field
    )
  {
    Field = field;
  }
}
