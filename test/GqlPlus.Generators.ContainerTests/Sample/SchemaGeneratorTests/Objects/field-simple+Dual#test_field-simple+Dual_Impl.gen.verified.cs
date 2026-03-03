//HintName: test_field-simple+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}field-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Dual;

public class testFieldSmplDual
  : GqlpModelImplementationBase
  , ItestFieldSmplDual
{
  public ItestFieldSmplDualObject? As_FieldSmplDual { get; set; }
}

public class testFieldSmplDualObject
  : GqlpModelImplementationBase
  , ItestFieldSmplDualObject
{
  public decimal Field { get; set; }

  public testFieldSmplDualObject
    ( decimal field
    )
  {
    Field = field;
  }
}
