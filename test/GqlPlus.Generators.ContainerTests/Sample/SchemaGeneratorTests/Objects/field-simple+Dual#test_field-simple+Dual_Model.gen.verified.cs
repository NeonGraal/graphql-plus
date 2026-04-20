//HintName: test_field-simple+Dual_Model.gen.cs
// Generated from {CurrentDirectory}field-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Dual;

public class testFieldSmplDual
  : GqlpModelBase
  , ItestFieldSmplDual
{
  public ItestFieldSmplDualObject? As_FieldSmplDual { get; set; }
}

public class testFieldSmplDualObject
  : GqlpModelBase
  , ItestFieldSmplDualObject
{
  public decimal Field { get; set; }

  public testFieldSmplDualObject
    ( decimal pfield
    )
  {
    Field = pfield;
  }
}
