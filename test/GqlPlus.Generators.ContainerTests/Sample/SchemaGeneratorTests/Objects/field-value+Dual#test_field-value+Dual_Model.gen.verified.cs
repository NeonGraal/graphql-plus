//HintName: test_field-value+Dual_Model.gen.cs
// Generated from {CurrentDirectory}field-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Dual;

public class testFieldValueDual
  : GqlpModelBase
  , ItestFieldValueDual
{
  public ItestFieldValueDualObject? As_FieldValueDual { get; set; }
}

public class testFieldValueDualObject
  : GqlpModelBase
  , ItestFieldValueDualObject
{
  public testEnumFieldValueDual Field { get; set; }

  public testFieldValueDualObject
    ( testEnumFieldValueDual pfield
    )
  {
    Field = pfield;
  }
}
