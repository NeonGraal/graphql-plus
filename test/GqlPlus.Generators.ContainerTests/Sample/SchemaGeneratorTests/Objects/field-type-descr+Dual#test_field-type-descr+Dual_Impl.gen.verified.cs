//HintName: test_field-type-descr+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Dual;

public class testFieldTypeDescrDual
  : GqlpModelImplementationBase
  , ItestFieldTypeDescrDual
{
  public ItestFieldTypeDescrDualObject? As_FieldTypeDescrDual { get; set; }
}

public class testFieldTypeDescrDualObject
  : GqlpModelImplementationBase
  , ItestFieldTypeDescrDualObject
{
  public decimal Field { get; set; }

  public testFieldTypeDescrDualObject(decimal field)
  {
    Field = field;
  }
}
