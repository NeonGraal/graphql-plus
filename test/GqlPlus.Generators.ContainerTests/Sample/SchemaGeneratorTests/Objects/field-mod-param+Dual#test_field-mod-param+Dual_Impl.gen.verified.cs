//HintName: test_field-mod-param+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Dual;

public class testFieldModParamDual<TMod>
  : GqlpModelImplementationBase
  , ItestFieldModParamDual<TMod>
{
  public ItestFieldModParamDualObject<TMod>? As_FieldModParamDual { get; set; }
}

public class testFieldModParamDualObject<TMod>
  : GqlpModelImplementationBase
  , ItestFieldModParamDualObject<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamDual> Field { get; set; }

  public testFieldModParamDualObject(IDictionary<TMod, ItestFldFieldModParamDual> field)
  {
    Field = field;
  }
}

public class testFldFieldModParamDual
  : GqlpModelImplementationBase
  , ItestFldFieldModParamDual
{
  public string? AsString { get; set; }
  public ItestFldFieldModParamDualObject? As_FldFieldModParamDual { get; set; }
}

public class testFldFieldModParamDualObject
  : GqlpModelImplementationBase
  , ItestFldFieldModParamDualObject
{
  public decimal Field { get; set; }

  public testFldFieldModParamDualObject(decimal field)
  {
    Field = field;
  }
}
