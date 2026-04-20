//HintName: test_field-type-descr+Dual_Model.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Dual;

public class testFieldTypeDescrDual
  : GqlpModelBase
  , ItestFieldTypeDescrDual
{
  public ItestFieldTypeDescrDualObject? As_FieldTypeDescrDual { get; set; }
}

public class testFieldTypeDescrDualObject
  : GqlpModelBase
  , ItestFieldTypeDescrDualObject
{
  public decimal Field { get; set; }

  public testFieldTypeDescrDualObject
    ( decimal pfield
    )
  {
    Field = pfield;
  }
}
