//HintName: test_Dual_Intf.gen.cs
// Generated from {CurrentDirectory}Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Dual;

public interface Itest_DualField
  : Itest_ObjField<Itest_ObjFieldType>
{
  Itest_DualFieldObject As_DualField { get; }
}

public interface Itest_DualFieldObject
  : Itest_ObjFieldObject<Itest_ObjFieldType>
{
}
