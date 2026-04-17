//HintName: test_field-dual+Dual_Model.gen.cs
// Generated from {CurrentDirectory}field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Dual;

public class testFieldDualDual
  : GqlpModelBase
  , ItestFieldDualDual
{
  public ItestFieldDualDualObject? As_FieldDualDual { get; set; }
}

public class testFieldDualDualObject
  : GqlpModelBase
  , ItestFieldDualDualObject
{
  public ItestFldFieldDualDual Field { get; set; }

  public testFieldDualDualObject
    ( ItestFldFieldDualDual field
    )
  {
    Field = field;
  }
}

public class testFldFieldDualDual
  : GqlpModelBase
  , ItestFldFieldDualDual
{
  public string? AsString { get; set; }
  public ItestFldFieldDualDualObject? As_FldFieldDualDual { get; set; }
}

public class testFldFieldDualDualObject
  : GqlpModelBase
  , ItestFldFieldDualDualObject
{
  public decimal Field { get; set; }

  public testFldFieldDualDualObject
    ( decimal field
    )
  {
    Field = field;
  }
}
