//HintName: test_field+Dual_Model.gen.cs
// Generated from {CurrentDirectory}field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Dual;

public class testFieldDual
  : GqlpModelBase
  , ItestFieldDual
{
  public ItestFieldDualObject? As_FieldDual { get; set; }
}

public class testFieldDualObject
  : GqlpModelBase
  , ItestFieldDualObject
{
  public string Field { get; set; }

  public testFieldDualObject
    ( string field
    )
  {
    Field = field;
  }
}
