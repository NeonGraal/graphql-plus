//HintName: test_field+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Dual;

public class testFieldDual
  : GqlpModelImplementationBase
  , ItestFieldDual
{
  public ItestFieldDualObject? As_FieldDual { get; set; }
}

public class testFieldDualObject
  : GqlpModelImplementationBase
  , ItestFieldDualObject
{
  public string Field { get; set; }

  public testFieldDualObject(string field)
  {
    Field = field;
  }
}
