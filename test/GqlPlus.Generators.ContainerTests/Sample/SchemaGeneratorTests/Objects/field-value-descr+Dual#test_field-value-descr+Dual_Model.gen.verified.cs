//HintName: test_field-value-descr+Dual_Model.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Dual;

public class testFieldValueDescrDual
  : GqlpModelBase
  , ItestFieldValueDescrDual
{
  public ItestFieldValueDescrDualObject? As_FieldValueDescrDual { get; set; }
}

public class testFieldValueDescrDualObject
  : GqlpModelBase
  , ItestFieldValueDescrDualObject
{
  public testEnumFieldValueDescrDual Field { get; set; }

  public testFieldValueDescrDualObject
    ( testEnumFieldValueDescrDual field
    )
  {
    Field = field;
  }
}
