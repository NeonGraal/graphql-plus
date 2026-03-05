//HintName: test_field-descr+Dual_Model.gen.cs
// Generated from {CurrentDirectory}field-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_descr_Dual;

public class testFieldDescrDual
  : GqlpModelImplementationBase
  , ItestFieldDescrDual
{
  public ItestFieldDescrDualObject? As_FieldDescrDual { get; set; }
}

public class testFieldDescrDualObject
  : GqlpModelImplementationBase
  , ItestFieldDescrDualObject
{
  public string Field { get; set; }

  public testFieldDescrDualObject
    ( string field
    )
  {
    Field = field;
  }
}
