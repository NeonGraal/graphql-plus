//HintName: test_field-dual+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Dual;

public class testFieldDualDual
  : GqlpModelImplementationBase
  , ItestFieldDualDual
{
  public ItestFieldDualDualObject? As_FieldDualDual { get; set; }
}

public class testFieldDualDualObject
  : GqlpModelImplementationBase
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
  : GqlpModelImplementationBase
  , ItestFldFieldDualDual
{
  public string? AsString { get; set; }
  public ItestFldFieldDualDualObject? As_FldFieldDualDual { get; set; }
}

public class testFldFieldDualDualObject
  : GqlpModelImplementationBase
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
