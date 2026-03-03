//HintName: test_field-dual+Input_Impl.gen.cs
// Generated from {CurrentDirectory}field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Input;

public class testFieldDualInp
  : GqlpModelImplementationBase
  , ItestFieldDualInp
{
  public ItestFieldDualInpObject? As_FieldDualInp { get; set; }
}

public class testFieldDualInpObject
  : GqlpModelImplementationBase
  , ItestFieldDualInpObject
{
  public ItestFldFieldDualInp Field { get; set; }

  public testFieldDualInpObject
    ( ItestFldFieldDualInp field
    )
  {
    Field = field;
  }
}

public class testFldFieldDualInp
  : GqlpModelImplementationBase
  , ItestFldFieldDualInp
{
  public string? AsString { get; set; }
  public ItestFldFieldDualInpObject? As_FldFieldDualInp { get; set; }
}

public class testFldFieldDualInpObject
  : GqlpModelImplementationBase
  , ItestFldFieldDualInpObject
{
  public decimal Field { get; set; }

  public testFldFieldDualInpObject
    ( decimal field
    )
  {
    Field = field;
  }
}
