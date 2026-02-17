//HintName: test_field-object+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}field-object+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Dual;

public class testFieldObjDual
  : ItestFieldObjDual
{
  public ItestFldFieldObjDual Field { get; set; }
}

public class testFldFieldObjDual
  : ItestFldFieldObjDual
{
  public decimal Field { get; set; }
}
